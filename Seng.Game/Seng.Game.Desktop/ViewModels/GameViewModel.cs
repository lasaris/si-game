using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class GameViewModel : BaseViewModel
	{
		private bool isDesktopButtonChecked;

		public bool IsDesktopButtonChecked
		{
			get => isDesktopButtonChecked;
			set => SetProperty(ref isDesktopButtonChecked, value);
		}

		public DelegateCommand<string> NavigateCommand { get; set; }

		public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			NavigateCommand = new DelegateCommand<string>(NavigateCommandExecute);

			isDesktopButtonChecked = true;
			regionManager.RegisterViewWithRegion(Regions.RibbonRegion, Regions.DesktopModuleViewType);
		}

		private void NavigateCommandExecute(string navigatePath)
		{
			if (navigatePath != null)
			{
				RegionManager.RequestNavigate(Regions.RibbonRegion, navigatePath);
			}
		}
	}
}