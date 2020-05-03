using Seng.Common.Entities.Actions.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class SendEmailToPlayerActionCommand : IActionCommand
    {
        public SendEmailToPlayerAction ActionData { get; set; }
    }
}
