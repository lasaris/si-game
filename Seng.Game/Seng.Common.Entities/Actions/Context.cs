using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class Context
    {
        public int Id { get; set; }
        public int? ClickedComponentId { get; set; }
        public int? AlreadyRunActionId { get; set; }
        public int OnClickOptionId { get; set; }
        public int? InLast { get; set; }
        public int? InFirst { get; set; }
    }
}
