using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class ParagraphComponent : BasicEntity
	{
		public string Text { get; set; }

		public IEnumerable<ParagraphComponent> ChildrenParagraphs { get; set; }
	}
}