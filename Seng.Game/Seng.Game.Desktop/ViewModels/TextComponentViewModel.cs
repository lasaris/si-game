using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace Seng.Game.Desktop.ViewModels
{
	public class TextComponentViewModel : BindableBase
	{
		public DelegateCommand ConfirmationCommand { get; set; }

		public TextComponentViewModel()
		{
			ConfirmationCommand = new DelegateCommand(Confirmation);
		}

		private void Confirmation()
		{
			MessageBox.Show("Vyvolání akce");
		}
	}
}