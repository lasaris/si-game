using System;
using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
	public class EmailComponent : BasicEntity
	{
		public string Sender { get; set; }

		public string Subject { get; set; }

		public DateTime Date { get; set; }

		public string ContentHeader { get; set; }

		public IEnumerable<string> Paragraphs { get; set; }

		public string ContentFooter { get; set; }
	}
}