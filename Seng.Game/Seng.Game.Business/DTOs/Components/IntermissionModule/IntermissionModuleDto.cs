using Seng.Game.Business.DTOs.Components.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class IntermissionModuleDto : BasicModuleDto
    {
        public IEnumerable<IntermissionFrameComponentDto> Frames { get; set; }
    }
}
