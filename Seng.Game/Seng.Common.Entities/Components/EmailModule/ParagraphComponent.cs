using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class ParagraphComponent : BasicEntity
	{
        public int ComponentId { get; set; }

		public string Text { get; set; }

        public int? ParentParagraphId { get; set; }

        public int RecipientComponentId { get; set; }

		public IEnumerable<ParagraphComponent> ChildrenParagraphs { get; set; }
	}
}