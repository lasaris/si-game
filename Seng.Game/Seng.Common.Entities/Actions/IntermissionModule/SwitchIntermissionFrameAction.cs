using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions.IntermissionModule
{
    public class SwitchIntermissionFrameAction
    {
        public int ActionId { get; set; }
        public int NewIntermissionFrameComponentId { get; set; }
        public int IntermissionModuleId { get; set; }
    }
}
