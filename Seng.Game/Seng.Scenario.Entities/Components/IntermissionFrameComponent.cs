using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Entities.Components
{
    public class IntermissionFrameComponent : BasicEntity
    {
        public Component BasicComponentInfo { get; set; }

        public IEnumerable<TextComponent> TextParagraphs { get; set; }

        public IEnumerable<QuestionComponent> Questions { get; set; }

        public ButtonComponent Button { get; set; }
    }
}
