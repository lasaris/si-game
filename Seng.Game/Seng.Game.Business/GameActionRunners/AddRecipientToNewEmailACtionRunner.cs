using MediatR;
using Seng.Common.Entities.Actions.EmailModule;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.GameActionRunners
{
    class AddRecipientToNewEmailACtionRunner : IGameActionRunner
    {
        private IMediator _mediator;

        public AddRecipientToNewEmailACtionRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> RunGameAction(int gameActionId)
        {
            var query = new GetAddRecipientToNewEmailActionQuery
            {
                GameActionId = gameActionId
            };
            AddRecipientToNewEmailAction actionData = await _mediator.Send(query);

            var command = new MakeRecipientActiveCommand
            {
                RecipientId = actionData.RecipientComponentId
            };
            return await _mediator.Send(command);
        }
    }
}
