using Seng.Common.Entities.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class IntermissionModule
    {
        public int ModuleId { get; set; }
        public int? CurrentlyVisibleFrameId { get; set; }

        public IEnumerable<IntermissionFrameComponent> IntermissionFrameComponents { get; set; } = new List<IntermissionFrameComponent>();

        public Module Module { get; set; }
    }
}
