using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Modules
{
    public class AllGameModulesBasicInfoDto
    {
        public BasicModuleDto IntermissionModuleInfo { get; set; }

        public BasicModuleDto EmailModuleInfo { get; set; }

        public BasicModuleDto BrowserModuleInfo { get; set; }
    }
}
