using System;
using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class EmailComponent
    {
        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTime Date { get; set; }

        public string ContentHeader { get; set; }

        public IEnumerable<EmailComponentParagraph> Paragraphs { get; set; }

        public string ContentFooter { get; set; }

        public int ComponentId { get; set; }

        public bool IsSentEmail { get; set; }

        public bool Active { get; set; }
    }
}