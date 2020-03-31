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

		public bool IsBrowserModuleVisible => GameState.BrowserModule.IsVisible;
		public bool IsEmailModuleVisible => GameState.EmailModule.IsVisible;

		public DelegateCommand<string> ModuleNavigateCommand { get; set; }

		public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			ModuleNavigateCommand = new DelegateCommand<string>(ModuleNavigateCommandExecute);

			if (GameState.DesktopModule.IsVisible)
			{
				IsDesktopButtonChecked = true;
				regionManager.RegisterViewWithRegion(Regions.ModuleRegion, Regions.DesktopModuleViewType);
			}
		}

		private void ModuleNavigateCommandExecute(string moduleView)
		{
			RegionManager.RequestNavigate(Regions.ModuleRegion, moduleView);
		}
	}
}