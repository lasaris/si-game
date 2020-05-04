using MediatR;
using Seng.Common.Entities.Actions.EmailModule;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.GameActionRunners
{
    class SendEmailToPlayerActionRunner : IGameActionRunner
    {
        private IMediator _mediator;

        public SendEmailToPlayerActionRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> RunGameAction(int gameActionId)
        {
            var query = new GetSendEmailToPlayerActionDataQuery
            {
                GameActionId = gameActionId
            };
            SendEmailToPlayerAction actionData = await _mediator.Send(query);

            var insertComponentCommand = new InsertNewComponentCommand
            {
                ComponentId = actionData.ComponentId
            };
            await _mediator.Send(insertComponentCommand);

            var command = new CreateNewEmailCommand
            {
                Sender = actionData.Sender,
                Subject = actionData.Subject,
                Content = actionData.Content,
                ContentFooter = actionData.ContentFooter,
                ContentHeader = actionData.ContentHeader,
                Date = actionData.Date,
                EmailModuleId = actionData.EmailModuleId,
                ComponentId = actionData.ComponentId,
                IsSentEmail = false
            };
            return await _mediator.Send(command);
        }
    }
}
