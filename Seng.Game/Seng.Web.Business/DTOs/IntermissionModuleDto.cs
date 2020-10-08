using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class IntermissionModuleDto : ModuleBaseDto
    {
        public int CurrentIntermissionFrameId { get; set; }
        public IEnumerable<IntermissionFrameDto> IntermissionFrames { get; set; } = new List<IntermissionFrameDto>();
    }
}
