using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class Module : BasicEntity
    {
        public bool IsVisible { get; set; }
        public bool IsRunning { get; set; }
    }
}
