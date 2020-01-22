using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public abstract class BasicComponentDto : IComponentDto
    {
        public ComponentBasicInfoDto ComponentBasicInfo { get; set; }
    }
}
