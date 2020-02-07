using Seng.Game.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class ComponentInfo : BasicEntity
    {
        public ComponentType Type { get; set; }
        public List<ComponentInfo> ChildComponents { get; set; }
        public ActionInfo OnClickAction { get; set; }
        public List<OnClickOption> OnClickOptions { get; set; }
    }
}
