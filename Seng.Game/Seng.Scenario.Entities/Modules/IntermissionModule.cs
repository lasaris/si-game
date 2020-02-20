using Seng.Game.Entities.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities.Modules
{
    public class IntermissionModule : BasicEntity
    {
        public Component BasicComponentInfo { get; set; }

        public IEnumerable<IntermissionFrameComponent> Frames { get; set; }
    }
}
