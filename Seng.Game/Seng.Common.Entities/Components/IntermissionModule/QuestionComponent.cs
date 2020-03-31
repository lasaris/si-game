using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class QuestionComponent : BasicEntity
    {
        public int ComponentId { get; set; }
        public string Text { get; set; }
        public bool Multichoice { get; set; }
    }
}
