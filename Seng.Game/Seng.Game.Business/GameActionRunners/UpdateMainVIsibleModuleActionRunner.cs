using MediatR;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.GameActionRunners
{
    class UpdateMainVIsibleModuleActionRunner : IGameActionRunner
    {
        private IMediator _mediator;

        public UpdateMainVIsibleModuleActionRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> RunGameAction(int gameActionId)
        {
            var query = new GetUpdateMainVIsibleModuleActionDataQuery
            {
                ActionId = gameActionId
            };
            var actionData = await _mediator.Send(query);

            var command = new UpdateMainVisibleModuleActionCommand
            {
                MainVisibleModuleId = actionData.NewMainVisibleModuleId
            };
            return await _mediator.Send(command);
        }
    }
}
