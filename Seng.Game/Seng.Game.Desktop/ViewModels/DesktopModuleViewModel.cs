using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class DesktopModuleViewModel : BaseViewModel
	{
		public DesktopModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState) { }
	}
}