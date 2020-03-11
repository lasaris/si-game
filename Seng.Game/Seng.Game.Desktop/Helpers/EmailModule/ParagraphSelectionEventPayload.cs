using Seng.Game.Business.DTOs.Components.EmailModule;

namespace Seng.Game.Desktop.Helpers.EmailModule
{
	public class ParagraphSelectionEventPayload
	{
		public ParagraphComponentDto Selected { get; set; }

		public ParagraphSelectionPurpose Purpose { get; set; }
	}
}