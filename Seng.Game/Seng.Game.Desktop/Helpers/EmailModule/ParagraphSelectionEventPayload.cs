using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.EmailModule;

namespace Seng.Game.Desktop.Helpers.EmailModule
{
	public class ParagraphSelectionEventPayload
	{
		public List<ParagraphComponentDto> ParagraphOptions { get; set; }

		public ParagraphComponentDto SelectedParagraph { get; set; }

		public ParagraphSelectionPurpose Purpose { get; set; }
	}
}