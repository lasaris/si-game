using Seng.Game.Business.DTOs.Components.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class IntermissionModuleDto : IComponentDto
    {
        public ComponentBasicInfoDto ComponentBasicInfo { get; set; }

        public IEnumerable<IComponentDto> ChildComponents { get; set; }
    }
}
