﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class ContextActionCondition : BasicEntity
    {
        public GameAction ActionInContext { get; set; }
        public int NumberOfFirstActions { get; set; }
        public int NumberOfLastActions { get; set; }
    }
}
