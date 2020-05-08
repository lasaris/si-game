using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class EmailModule : BasicEntity
    {
        public int ModuleId { get; set; }

        public Module Module { get; set; }

        public IEnumerable<EmailComponent> RegularEmails { get; set; }

        public IEnumerable<EmailComponent> SentEmails { get; set; }

        public IEnumerable<RecipientComponent> Recipients { get; set; }

        public string NewEmailSubject { get; set; }
    }
}
