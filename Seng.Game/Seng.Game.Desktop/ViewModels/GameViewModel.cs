using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class GameViewModel : BaseViewModel
	{
		public DelegateCommand<string> NavigateCommand { get; set; }

		public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			NavigateCommand = new DelegateCommand<string>(NavigateCommandExecute);
		}

		private void NavigateCommandExecute(string navigatePath)
		{
			if (navigatePath != null)
			{
				RegionManager.RequestNavigate(Regions.MainRibbonRegion, navigatePath);
			}
		}
	}
}