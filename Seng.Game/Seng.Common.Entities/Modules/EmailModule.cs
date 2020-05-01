using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class EmailModule
    {
        public IEnumerable<EmailComponent> RegularEmails { get; set; }

        public IEnumerable<EmailComponent> SentEmails { get; set; }

        public NewEmailComponent NewEmail { get; set; }
    }
}
