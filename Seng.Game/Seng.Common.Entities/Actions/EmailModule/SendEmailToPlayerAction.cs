using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions.EmailModule
{
    public class SendEmailToPlayerAction : BasicEntity
    {
        public int ActionId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string ContentHeader { get; set; }
        public string ContentFooter { get; set; }
        public string Content { get; set; }
        public int EmailModuleId { get; set; }
        public int ComponentId { get; set; }
    }
}
