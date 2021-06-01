using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class MinigameSelectionViewModel : BaseViewModel
	{
		public DelegateCommand OpenSearchingMinigameCommand { get; set; }
		public DelegateCommand OpenUnlockManafloidsMinigameCommand { get; set; }
		public DelegateCommand BubblesMinigameCommand { get; set; }
		public DelegateCommand SneakMinigameCommand { get; set; }


		public MinigameSelectionViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			OpenSearchingMinigameCommand = new DelegateCommand(OpenSearchingMinigameCommandExecute);
			OpenUnlockManafloidsMinigameCommand = new DelegateCommand(OpenUnlockManafloidsMinigameCommandExecute);
			BubblesMinigameCommand = new DelegateCommand(BubblesMinigameCommandExecute);
			SneakMinigameCommand = new DelegateCommand(SneakMinigameCommandExecute);
		}

		private void OpenSearchingMinigameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.SearchingMinigameView);
		}

		private void OpenUnlockManafloidsMinigameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.NumbersMinigameView);
		}

		private void BubblesMinigameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.BubleClickerView);
		}

		private void SneakMinigameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.SneakMinigameView);
		}
	}
}