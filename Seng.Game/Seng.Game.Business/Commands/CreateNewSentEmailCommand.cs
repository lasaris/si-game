using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class CreateNewSentEmailCommand : ICommand<bool>
    {
        public string Subject { get; set; }

        public string Sender { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string ContentHeader { get; set; }

        public string ContentFooter { get; set; }

        public int EmailModuleId { get; set; }

        public int ComponentId { get; set; }
    }
}
