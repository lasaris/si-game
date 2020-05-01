using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class ParagraphComponent
	{
		public string Text { get; set; }

		public IEnumerable<ParagraphComponent> ChildrenParagraphs { get; set; }

		public bool Selected { get; set; }
	}
}