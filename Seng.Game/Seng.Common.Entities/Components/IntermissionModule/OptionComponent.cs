using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class OptionComponent : BasicEntity
    {
        public int ComponentId { get; set; }
        public string Text { get; set; }
        public int QuestionComponentId { get; set; }
    }
}
