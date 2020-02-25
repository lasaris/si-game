using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class ComponentsStatesCondition : BasicEntity
    {
        //List of ids, or whole components?
        public List<Component> ClickedComponents { get; set; }
    }
}
