using Seng.Common.Entities.Actions.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class CreateNewEmailCommand : ICommand<bool>
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string ContentHeader { get; set; }
        public string ContentFooter { get; set; }
        public string Content { get; set; }
        public int EmailModuleId { get; set; }
        public int ComponentId { get; set; }
        public bool IsSentEmail { get; set; }
    }
}
