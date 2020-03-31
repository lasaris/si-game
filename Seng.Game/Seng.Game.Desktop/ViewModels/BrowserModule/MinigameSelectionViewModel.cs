using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class MinigameSelectionViewModel : BaseViewModel
	{
		public DelegateCommand OpenSearchingMinigameCommand { get; set; }

		public MinigameSelectionViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			OpenSearchingMinigameCommand = new DelegateCommand(OpenSearchingMinigameCommandExecute);
		}

		private void OpenSearchingMinigameCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.SearchingMinigameView);
		}
	}
}