using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Seng.Game.Desktop.ViewModels.Base
{
	public abstract class BaseViewModel : BindableBase
	{
		protected IRegionManager RegionManager;
		protected IEventAggregator EventAggregator;

		protected GameState GameState;

		protected BaseViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
		{
			RegionManager = regionManager;
			EventAggregator = eventAggregator;

			GameState = gameState;
		}

		protected void ShowIntermission()
		{
			RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.IntermissionModuleView);
		}
	}
}