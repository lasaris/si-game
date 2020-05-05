using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	/// <summary>
	/// Class represents pause (options) state of the application.
	/// </summary>
	public class PauseViewModel : BaseViewModel, INavigationAware
	{
		private string pausedView;

		public DelegateCommand ChangeThemeCommand { get; set; }
		public DelegateCommand BackToGameCommand { get; set; }
		public DelegateCommand ExitApplicationCommand { get; set; }
		
		public PauseViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			ChangeThemeCommand = new DelegateCommand(ChangeThemeCommandExecute);
			BackToGameCommand = new DelegateCommand(BackToGameCommandExecute);
			ExitApplicationCommand = new DelegateCommand(ExitApplicationCommandExecute);
		}

		private void ChangeThemeCommandExecute()
		{
			GameTheme.ChangeThemeColor();
		}

		private void BackToGameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.ApplicationRegion, pausedView);
		}
		private void ExitApplicationCommandExecute()
		{
			//Things to be done before shutdown

			Application.Current.Shutdown();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => true;

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			pausedView = (string) navigationContext.Parameters["PausedView"];
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}