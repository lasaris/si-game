using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class EmailComponentParagraph
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int EmailComponentId { get; set; }
    }
}
