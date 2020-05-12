using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class RecipientComponent : BasicEntity
    {
        public int ComponentId { get; set; }

		public string Address { get; set; }

		public string Description { get; set; }

		public string ContentHeader { get; set; }

		public IEnumerable<NewEmailParagraphComponent> FirstParagraphs { get; set; }

		public string ContentFooter { get; set; }

        public int ButtonComponentId { get; set; }

        public ButtonComponent ButtonComponent { get; set; }
    }
}