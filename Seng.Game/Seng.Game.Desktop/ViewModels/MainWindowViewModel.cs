using System.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private string pausedView;

		public DelegateCommand PauseApplicationCommand { get; set; }

		public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			PauseApplicationCommand = new DelegateCommand(PauseApplicationCommandExecute);

			RegionManager.RegisterViewWithRegion(Regions.ApplicationRegion,
				GameState.IntermissionModule.IsVisible ? Regions.IntermissionModuleViewType : Regions.GameViewType);
		}

		private void PauseApplicationCommandExecute()
		{
			var currentViewType = RegionManager.Regions["ApplicationRegion"].ActiveViews.FirstOrDefault()?.GetType();

			if (currentViewType == Regions.PauseViewType)
			{
				RegionManager.RequestNavigate(Regions.ApplicationRegion, pausedView);
			}
			else
			{
				pausedView = currentViewType?.ToString();

				RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.PauseView,
					new NavigationParameters { { "PausedView", pausedView } });
			}
		}
	}
}