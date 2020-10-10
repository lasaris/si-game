﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class EmailModuleDto : ModuleBaseDto
    {
        public string NewEmailSubject { get; set; }
        public IEnumerable<EmailDto> SentEmails { get; set; } = new List<EmailDto>();
        public IEnumerable<EmailDto> ReceivedEmails { get; set; } = new List<EmailDto>();
        public IEnumerable<RecipientComponentDto> Recipients { get; set; } = new List<RecipientComponentDto>();
    }
}
