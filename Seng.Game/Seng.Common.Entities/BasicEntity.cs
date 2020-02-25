using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities
{
    public abstract class BasicEntity : IEntity
    {
        public int Id { get; set; }
    }
}
