using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class RecipientComponent
	{
		public string Address { get; set; }

		public string Description { get; set; }

		public string ContentHeader { get; set; }

		public IEnumerable<ParagraphComponent> FirstParagraphs { get; set; }

		public string ContentFooter { get; set; }

		public bool Selected { get; set; }
	}
}