using AutoMapper;
using MediatR;
using Seng.Common.Entities.Actions;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    public abstract class GetModuleRequestHandler<TModuleDto> : IRequestHandler<GetModuleRequest<TModuleDto>, TModuleDto>
        where TModuleDto : IModuleDto
    {
        private IMediator _mediator;

        protected abstract IDictionary<string, Func<TModuleDto, IActionCommand>> ActionCommandResolver { get; }

        public GetModuleRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TModuleDto> Handle(GetModuleRequest<TModuleDto> request, CancellationToken cancellationToken)
        {
            int moduleId = request.Module?.ModuleId ?? throw new ArgumentNullException(nameof(request.Module));
            if (!request.TriggeredComponentId.HasValue)
            {
                return await RetrieveModule(moduleId);
            }

            var getActionQuery = new GetActionByComponentQuery
            {
                ClickedComponentIds = GetClickedComponentIds(request.Module).ToArray(),
                ComponentId = request.TriggeredComponentId.Value
            };
            IEnumerable<GameAction> gameActionsToRun = await _mediator.Send(getActionQuery);

            foreach(var gameAction in gameActionsToRun)
            {
                bool actionExists = ActionCommandResolver.TryGetValue(gameAction.Type, out Func<TModuleDto, IActionCommand> actionCommandCreator);
                if (!actionExists)
                {
                    throw new ArgumentException($"No action command for action type {gameAction.Type}");
                }
                var actionCommand = actionCommandCreator(request.Module);
                actionCommand.GameActionId = gameAction.Id;
                await _mediator.Send(actionCommand);
            }
            await UpdateDataBasedOnModuleState(request.Module);

            return await RetrieveModule(moduleId);
        }

        protected abstract Task UpdateDataBasedOnModuleState(TModuleDto moduleDto);

        protected abstract IEnumerable<int> GetClickedComponentIds(TModuleDto moduleDto);

        protected abstract Task<TModuleDto> RetrieveModule(int moduleId);
    }
}
