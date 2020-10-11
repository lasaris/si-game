using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class EmailModuleDto : ModuleBaseDto
    {
        public string NewEmailSubject { get; set; }
        public IEnumerable<EmailComponentDto> SentEmails { get; set; } = new List<EmailComponentDto>();
        public IEnumerable<EmailComponentDto> ReceivedEmails { get; set; } = new List<EmailComponentDto>();
        public IEnumerable<RecipientComponentDto> Recipients { get; set; } = new List<RecipientComponentDto>();
    }
}
