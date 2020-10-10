using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class NewEmailParagraphComponent
	{
        public int ComponentId { get; set; }

		public string Text { get; set; }

        public int? ParentParagraphId { get; set; }

        public int RecipientComponentId { get; set; }

		public IEnumerable<NewEmailParagraphComponent> ChildrenParagraphs { get; set; }
	}
}