using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public class ModulBasicStateDto
    {
        public ComponentBasicInfoDto ComponentInfo { get; set; }

        public bool IsVisible { get; set; }

        public bool IsRunning { get; set; }
    }
}
