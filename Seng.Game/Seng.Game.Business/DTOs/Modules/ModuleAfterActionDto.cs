using Seng.Game.Business.DTOs.Components.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Modules
{
    public class ModuleAfterActionDto<TModuleDto> 
        where TModuleDto : BasicModuleDto
    {
        public TModuleDto CurrentModule { get; set; }

        public ModulesInfoDto ModulesInfo { get; set; }
    }
}
