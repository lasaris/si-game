using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Seng.Game.Desktop.ViewModels
{
	public class NewEmailViewModel : BindableBase
	{
		private readonly IRegionManager regionManager;

		public DelegateCommand DiscardButtonCommand { get; set; }

		public NewEmailViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;

			DiscardButtonCommand = new DelegateCommand(DiscardButtonCommandExecute);
		}

		private void DiscardButtonCommandExecute()
		{
			regionManager.RequestNavigate(Regions.EmailRegion, Regions.EmptyEmailView);
		}
	}
}