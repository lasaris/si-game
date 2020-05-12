using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.EmailModule
{
	public class RecipientComponentDto : BasicComponentDto
	{
		public string Address { get; set; }

		public string Description { get; set; }

		public string ContentHeader { get; set; }

		public IEnumerable<ParagraphComponentDto> FirstParagraphs { get; set; }

		public string ContentFooter { get; set; }

		public bool Selected { get; set; }

        public ButtonComponentDto SendButton { get; set; }
    }
}