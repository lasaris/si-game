using Prism.Commands;
using Prism.Mvvm;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Desktop.Views;

namespace Seng.Game.Desktop.ViewModels.Base
{
	public abstract class BaseViewModel : BindableBase, IControlable
	{
		private IntermissionModuleDto _intermissionModule;

		public IntermissionModuleDto IntermissionModule
		{
			get => _intermissionModule;
			set => SetProperty(ref _intermissionModule, value);
		}

		public DelegateCommand IntermissionCommand { get; set; }

		protected BaseViewModel()
		{
			_intermissionModule = GameInitialize.IntermissionModuleGet();

			IntermissionCommand = new DelegateCommand(ShowIntermission);
		}

		public void ShowIntermission()
		{
			IntermissionModuleView intermissionWindow = new IntermissionModuleView();
			intermissionWindow.ShowDialog();	
		}
	}
}