using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.EmailModule
{
	public class NewEmailComponentDto : BasicComponentDto
	{
		public IEnumerable<RecipientComponentDto> Recipients { get; set; }

		public string Subject { get; set; }

		public ButtonComponentDto SentButton { get; set; }
	}
}