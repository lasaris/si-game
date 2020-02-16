using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public DelegateCommand<ICloseable> ExitApplicationCommand { get; set; }

		public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			ExitApplicationCommand = new DelegateCommand<ICloseable>(ExitApplicationCommandExecute);

			RegionManager.RegisterViewWithRegion(Regions.ApplicationRegion,
				GameState.IntermissionModule.IsRunning ? Regions.IntermissionModuleViewType : Regions.GameViewType);
		}

		private void ExitApplicationCommandExecute(ICloseable window)
		{
			//Add exit confirmation, probably by Intermission

			window?.Close();
		}
	}
}