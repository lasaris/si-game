using System.Collections.Generic;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public interface IComponentDto
    {
        public int ComponentId { get; set; }

        public bool IsVisible { get; set; }

        public bool IsRunning { get; set; }
    }
}
