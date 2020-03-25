using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Modules
{
    public class BasicModuleDto : IModuleDto
    {
        public int ModuleId { get; set; }

        public bool IsVisible { get; set; }
    }
}
