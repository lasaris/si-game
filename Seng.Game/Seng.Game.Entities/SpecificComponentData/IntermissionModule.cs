using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities.SpecificComponentData
{
    public class IntermissionModule : BasicEntity
    {
        public IEnumerable<IntermissionFrameComponent> Frames { get; set; }
    }
}
