using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class GameAction
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int TimeFromTrigger { get; set; }
    }
}
