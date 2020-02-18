using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class PauseViewModel : BaseViewModel, INavigationAware
	{
		private string pausedView;

		public DelegateCommand ExitApplicationCommand { get; set; }

		public DelegateCommand BackToGameCommand { get; set; }

		public PauseViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			ExitApplicationCommand = new DelegateCommand(ExitApplicationCommandExecute);
			BackToGameCommand = new DelegateCommand(BackToGameCommandExecute);
		}

		private void ExitApplicationCommandExecute()
		{
			//Things to be done before shutdown

			Application.Current.Shutdown();
		}

		private void BackToGameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.ApplicationRegion, pausedView);
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => true;

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			pausedView = (string) navigationContext.Parameters["PausedView"];
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}