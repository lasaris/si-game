using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public class TextComponentDto : IComponentDto
    {
        public ComponentBasicInfoDto ComponentBasicInfo { get; set; }

        public IEnumerable<IComponentDto> ChildComponents { get; set; }

        public string Text { get; set; }
    }
}
