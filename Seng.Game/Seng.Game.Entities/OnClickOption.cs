using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class OnClickOption : BasicEntity
    {
        public ComponentsStatesCondition OtherComponentsStates { get; set; }
        public ContextActionCondition Context { get; set; }
        public ActionInfo ResultAction { get; set; }
    }
}
