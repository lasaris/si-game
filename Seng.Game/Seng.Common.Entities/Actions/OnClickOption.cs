using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class OnClickOption
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int ResultActionId { get; set; }
        public bool UseClickComponentConstraint { get; set; }
        public bool UseInLastConstraint { get; set; }
        public bool UseInFirstConstraint { get; set; }
    }
}
