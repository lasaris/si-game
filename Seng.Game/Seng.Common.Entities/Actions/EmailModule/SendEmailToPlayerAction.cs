using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions.EmailModule
{
    public class SendEmailToPlayerAction : BasicEntity
    {
        public int ActionId { get; set; }
        public int EmailComponentId { get; set; }
    }
}
