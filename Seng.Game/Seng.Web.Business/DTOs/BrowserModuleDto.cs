using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class BrowserModuleDto : ModuleBaseDto
    {
        public IEnumerable<SearchingMinigameDto> SearchingMinigames { get; set; } = new List<SearchingMinigameDto>();
    }
}
