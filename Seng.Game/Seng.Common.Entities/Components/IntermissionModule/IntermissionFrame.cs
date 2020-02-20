using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class IntermissionFrame : BasicEntity
    {
        public int IntermissionModuleId { get; set; }
        public int ComponentId { get; set; }
        public int ButtonId { get; set; }
    }
}
