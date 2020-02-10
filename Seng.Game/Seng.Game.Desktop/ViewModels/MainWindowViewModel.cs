using Prism.Commands;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private readonly IRegionManager _regionManager;

		public DelegateCommand<string> NavigateCommand { get; set; }

		public MainWindowViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			NavigateCommand = new DelegateCommand<string>(Navigate);

			if (IntermissionModule.IsRunning)
			{
				ShowIntermission();
			}
		}

		private void Navigate(string navigatePath)
		{
			if (navigatePath != null)
			{
				_regionManager.RequestNavigate(RegionNames.MainRibbonRegion, navigatePath);
			}
		}
	}
}