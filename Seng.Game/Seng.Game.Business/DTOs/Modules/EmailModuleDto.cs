using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.EmailModule;

namespace Seng.Game.Business.DTOs.Modules
{
    public class EmailModuleDto : BasicModuleDto
    {
	    public IEnumerable<EmailComponentDto> RegularEmails { get; set; }

        public IEnumerable<EmailComponentDto> SentEmails { get; set; }

        public NewEmailComponentDto NewEmail { get; set; }
    }
}