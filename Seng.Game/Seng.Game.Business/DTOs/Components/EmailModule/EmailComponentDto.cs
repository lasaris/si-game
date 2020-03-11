using System;
using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.EmailModule
{
	public class EmailComponentDto : BasicComponentDto
	{
		public string Sender { get; set; }

		public string Subject { get; set; }

		public DateTime Date { get; set; }

		public string ContentHeader { get; set; }

		public IEnumerable<string> Paragraphs { get; set; }

		public string ContentFooter { get; set; }
	}
}