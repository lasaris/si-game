using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions.IntermissionModule
{
    public class SwitchIntermissionFrameAction : BasicEntity
    {
        public int GameActionId { get; set; }
        public int NewIntermissionFrameComponentId { get; set; }
    }
}
