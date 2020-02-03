using Seng.Game.Entities.SpecificComponentData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public class Scenario : BasicEntity
    {
        public string Name { get; set; }

        public Author Author { get; set; }

        public IEnumerable<IntermissionModule> IntermissionModules { get; set; }
    }
}
