using Prism.Events;
using Seng.Game.Business.DTOs.Components.EmailModule;

namespace Seng.Game.Desktop.Events
{
	public class RecipientSelectionEvent : PubSubEvent<RecipientComponentDto>
	{
	}
}