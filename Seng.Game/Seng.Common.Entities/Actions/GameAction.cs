using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class GameAction : BasicEntity
    {
        public string Type { get; set; }

        public int TimeFromTrigger { get; set; }
    }
}
