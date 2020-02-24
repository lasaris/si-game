using Seng.Game.Business.DTOs.Components.Common;
using System.Collections.Generic;

namespace Seng.Game.Business.DTOs.Components.IntermissionModule
{
    public class QuestionComponentDto : BasicComponentDto
    {
        public string Text { get; set; }

        public IEnumerable<OptionComponentDto> Options { get; set; }

        public bool Multichoice { get; set; } = false;
    }
}