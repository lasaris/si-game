using Seng.Game.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class Component : BasicEntity
    {
        public Guid ComponentId { get; set; }
        public ComponentType Type { get; set; }
        public List<Component> ChildComponents { get; set; }
        public Action OnClickAction { get; set; }
        public List<OnClickOption> OnClickOptions { get; set; }
    }
}
