using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class IntermissionText : BasicEntity
    {
        public string Text { get; set; }
        public int ComponentId { get; set; }
        public int IntermissionFrameId { get; set; }
    }
}
