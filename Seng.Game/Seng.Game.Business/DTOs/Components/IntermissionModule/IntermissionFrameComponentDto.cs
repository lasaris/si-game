using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class IntermissionFrameComponentDto : BasicComponentDto
    {
        public TextComponentDto TextParagraph { get; set; }

        public QuestionComponentDto Question { get; set; }

        public ButtonComponentDto Button { get; set; }
    }
}