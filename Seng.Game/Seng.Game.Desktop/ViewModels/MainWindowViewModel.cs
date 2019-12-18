using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Seng.Game.Desktop.Views;

namespace Seng.Game.Desktop.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;

		public DelegateCommand<string> NavigateCommand { get; set; }

		public MainWindowViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			NavigateCommand = new DelegateCommand<string>(Navigate);
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