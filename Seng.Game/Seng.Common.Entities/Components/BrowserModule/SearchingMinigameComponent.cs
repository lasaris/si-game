using System.Collections.Generic;

namespace Seng.Common.Entities.Components.BrowserModule
{
	public class SearchingMinigameComponent : BasicEntity
	{
		public IEnumerable<string> Words { get; set; }

		public string Solution { get; set; }

		public bool IsCompleted { get; set; }

		public int Height { get; set; }

		public int Width { get; set; }
	}
}