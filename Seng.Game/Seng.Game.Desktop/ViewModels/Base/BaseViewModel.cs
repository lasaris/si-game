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

		public DelegateCommand ShowIntermissionCommand { get; set; }

		protected BaseViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
		{
			RegionManager = regionManager;
			EventAggregator = eventAggregator;

			GameState = gameState;

			ShowIntermissionCommand = new DelegateCommand(ShowIntermissionCommandExecute);
		}

		private void ShowIntermissionCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.IntermissionModuleView);
		}
	}
}