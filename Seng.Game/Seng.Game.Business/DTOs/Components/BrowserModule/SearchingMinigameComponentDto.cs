using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.Common;

namespace Seng.Game.Business.DTOs.Components.BrowserModule
{
	public class SearchingMinigameComponentDto : BasicComponentDto
	{
		public IEnumerable<string> Words { get; set; }

		public string Solution { get; set; }

		public bool IsCompleted { get; set; }

		public int Height { get; set; }

		public int Width { get; set; }
	}
}