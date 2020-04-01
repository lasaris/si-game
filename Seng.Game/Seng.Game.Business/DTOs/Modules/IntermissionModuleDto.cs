using Seng.Game.Business.DTOs.Components.IntermissionModule;
using System.Collections.Generic;

namespace Seng.Game.Business.DTOs.Modules
{
    public class IntermissionModuleDto : BasicModuleDto
    {
        public IEnumerable<IntermissionFrameComponentDto> Frames { get; set; }

        public int? CurrentVisibleIntermissionFrameId { get; set; }
    }
}