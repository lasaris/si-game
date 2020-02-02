using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public abstract class BasicComponentDto : IComponentDto
    {
        public int ComponentId { get; set; }

        public string ComponentName { get; set; }

        public bool IsVisible { get; set; }

        public bool IsRunning { get; set; }
    }
}
