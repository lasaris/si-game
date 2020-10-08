using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class ScenarioDataDto
    {
        public int VisibleModuleIdStart { get; set; }
        public IEnumerable<IntermissionModuleDto> IntermissionModules { get; set; } = new List<IntermissionModuleDto>();
        public IEnumerable<EmailModuleDto> EmailModules { get; set; } = new List<EmailModuleDto>();
        public IEnumerable<BrowserModuleDto> BrowserModules { get; set; } = new List<BrowserModuleDto>();
    }
}
