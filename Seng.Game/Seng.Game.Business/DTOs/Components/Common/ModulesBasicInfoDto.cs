using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public class ModulesBasicInfoDto
    {
        public IEnumerable<ComponentBasicInfoDto> Modules { get; set; }
    }
}
