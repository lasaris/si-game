using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public abstract class BasicComponentDto : IComponentDto
    {
        public int ComponentId { get; set; }
    }
}
