using MediatR;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.GameActionRunners
{
    class NextIntermissionFrameActionRunner : IGameActionRunner
    {
        private IMediator _mediator;

        public NextIntermissionFrameActionRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> RunGameAction(int gameActionId)
        {
            var command = new RunNextIntermissionFrameActionCommand
            {
                GameActionId = gameActionId
            };
            return await _mediator.Send(command);
        }
    }
}
