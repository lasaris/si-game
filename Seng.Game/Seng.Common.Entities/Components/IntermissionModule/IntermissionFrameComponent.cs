using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.IntermissionModule
{
    public class IntermissionFrameComponent
    {
        public int IntermissionModuleId { get; set; }
        public int ComponentId { get; set; }
        public int ButtonComponentId { get; set; }
        public string TextParagraph { get; set; }
        public int? QuestionComponentId { get; set; }
        public string FrameType { get; set; } // Text, Question, MultichoiceQuestion, UserInput

        public ButtonComponent ButtonComponent { get; set; }
        public QuestionComponent QuestionComponent { get; set; }
    }
}
