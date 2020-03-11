using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.EmailModule
{
	public class ParagraphComponentDto : BasicComponentDto
	{
		public string Text { get; set; }

		public IEnumerable<ParagraphComponentDto> ChildrenParagraphs { get; set; }

		public bool Selected { get; set; }
	}
}