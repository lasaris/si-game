﻿using Seng.Common.Entities.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetActionByComponentQuery : IQuery<GameAction>
    {
        public int ComponentId { get; set; }
    }
}
