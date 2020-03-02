using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class EmailModuleViewModel : BaseViewModel
	{
		public DelegateCommand NewEmailButtonCommand { get; set; }

		public EmailModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			NewEmailButtonCommand = new DelegateCommand(NewEmailButtonCommandExecute);

			regionManager.RegisterViewWithRegion(Regions.EmailRegion, Regions.EmptyEmailViewType);
		}

		private void NewEmailButtonCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.NewEmailView);
		}
	}
}