using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class QuestionComponent
    {
        public int ComponentId { get; set; }
        public string Text { get; set; }

        public IEnumerable<OptionComponent> OptionComponents { get; set; } = new List<OptionComponent>();
    }
}
