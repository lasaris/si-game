using System.Collections.Generic;

namespace Seng.Common.Entities.Components.EmailModule
{
    public class NewEmailComponent
	{
		public IEnumerable<RecipientComponent> Recipients { get; set; }

		public string Subject { get; set; }
	}
}