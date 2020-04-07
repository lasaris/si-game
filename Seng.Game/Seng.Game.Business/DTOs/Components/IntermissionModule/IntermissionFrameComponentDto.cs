﻿using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class IntermissionFrameComponentDto : BasicComponentDto
    {
        public string FrameType { get; set; } // Text, Question, MultichoiceQuestion, UserInput

        public string TextParagraph { get; set; }

        public string UserInput { get; set; }

        public QuestionComponentDto Question { get; set; }

        public ButtonComponentDto Button { get; set; }
    }
}