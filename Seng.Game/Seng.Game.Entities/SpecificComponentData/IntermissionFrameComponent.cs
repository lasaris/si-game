using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities.SpecificComponentData
{
    public class IntermissionFrameComponent : BasicEntity
    {
        public IEnumerable<TextComponent> TextParagraphs { get; set; }

        public IEnumerable<QuestionComponent> Questions { get; set; }

        public ButtonComponent Button { get; set; }
    }
}
