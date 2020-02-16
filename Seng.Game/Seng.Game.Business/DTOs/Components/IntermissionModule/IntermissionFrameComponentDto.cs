using Seng.Game.Business.DTOs.Components.Common;
using System.Collections.Generic;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class IntermissionFrameComponentDto : BasicComponentDto
    {
        public IEnumerable<TextComponentDto> TextParagraphs { get; set; }

        public IEnumerable<QuestionComponentDto> Questions { get; set; }

        public ButtonComponentDto Button { get; set; }
    }
}