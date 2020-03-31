using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class IntermissionModule : BasicEntity
    {
        public int ModuleId { get; set; }
        public int? CurrentlyVisibleFrameId { get; set; }
    }
}
