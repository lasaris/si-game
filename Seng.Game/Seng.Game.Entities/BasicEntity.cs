using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities
{
    public abstract class BasicEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
