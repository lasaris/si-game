using AutoMapper;
using MediatR;
using Seng.Common.Entities.Actions;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.GameActionRunners;
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
    abstract class GetModuleRequestHandler<TModuleDto> : IRequestHandler<GetModuleRequest<TModuleDto>, TModuleDto>
        where TModuleDto : IModuleDto
    {
        private IMediator _mediator;
        private IGameActionFactory _gameActionFactory;

        public GetModuleRequestHandler(IMediator mediator, IGameActionFactory gameActionFactory)
        {
            _mediator = mediator;
            _gameActionFactory = gameActionFactory;
            gameActionFactory.Register(GameActionType.UpdateMainVisibleModuleId, typeof(UpdateMainVIsibleModuleActionRunner));
        }

        public async Task<TModuleDto> Handle(GetModuleRequest<TModuleDto> request, CancellationToken cancellationToken)
        {
            int moduleId = request.Module?.ModuleId ?? throw new ArgumentNullException(nameof(request.Module));

            if (request.TriggeredComponentId.HasValue)
            {
                var getActionQuery = new GetActionByComponentQuery
                {
                    ClickedComponentIds = GetClickedComponentIds(request.Module).ToArray(),
                    ComponentId = request.TriggeredComponentId.Value
                };
                IEnumerable<GameAction> gameActionsToRun = await _mediator.Send(getActionQuery);

                foreach (var gameAction in gameActionsToRun)
                {
                    _ = Task.Run(() => RunAction(gameAction, gameAction.TimeFromTrigger)).ConfigureAwait(false);
                }
            }

            await UpdateDataBasedOnModuleState(request.Module);

            var module = await RetrieveModule(moduleId);

            var getNewMainVisibleModule = new GetCommonGameDataQuery();
            var commonGameData = await _mediator.Send(getNewMainVisibleModule);
            module.NewMainVisibleModuleId = commonGameData.MainVisibleModuleId;
            return module;
        }

        protected abstract Task UpdateDataBasedOnModuleState(TModuleDto moduleDto);

        protected abstract IEnumerable<int> GetClickedComponentIds(TModuleDto moduleDto);

        protected abstract Task<TModuleDto> RetrieveModule(int moduleId);

        private async Task RunAction(GameAction gameAction, int timeToWait)
        {
            await Task.Delay(timeToWait);
            var gameActionRunner = _gameActionFactory.GetGameActionRunner(Enum.Parse<GameActionType>(gameAction.Type));
            await gameActionRunner.RunGameAction(gameAction.Id);
        }
    }
}
