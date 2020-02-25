using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Modules
{
    public class IntermissionModuleDto : BasicModuleDto
    {
        public IEnumerable<IntermissionFrameComponentDto> Frames { get; set; }

        public int CurrentVisibleIntermissionFrameId { get; set; }
    }
}
