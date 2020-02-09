using Seng.Game.Business.DTOs.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public class BasicModuleDto : IComponentDto
    {
        public int ComponentId { get; set; }

        public bool IsRunning { get; set; }

        public bool IsVisible { get; set; }
    }
}
