using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class EmailModuleViewModel : BaseViewModel
	{
		private EmailModuleDto emailModule;

		private ObservableCollection<EmailComponentDto> emailList = new ObservableCollection<EmailComponentDto>();

		public ObservableCollection<EmailComponentDto> EmailList
		{
			get => emailList;
			set => SetProperty(ref emailList, value);
		}

		public DelegateCommand NewEmailCommand { get; set; }
		public DelegateCommand ShowInboxEmailsCommand { get; set; }
		public DelegateCommand<EmailComponentDto> ViewEmailFromListCommand { get; set; }

		public EmailModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			NewEmailCommand = new DelegateCommand(NewEmailCommandExecute);
			ShowInboxEmailsCommand = new DelegateCommand(ShowInboxEmailsCommandExecute);
			ViewEmailFromListCommand = new DelegateCommand<EmailComponentDto>(ViewEmailFromListCommandExecute);

			emailModule = gameState.EmailModule;

			regionManager.RegisterViewWithRegion(Regions.EmailRegion, Regions.EmptyEmailViewType);
		}

		private void ViewEmailFromListCommandExecute(EmailComponentDto email)
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.DisplayEmailView,
				new NavigationParameters { {"Email", email} });
		}

		private void ShowInboxEmailsCommandExecute()
		{
			EmailList.Clear();

			EmailList.AddRange(emailModule.RegularEmails);
		}

		private void NewEmailCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.NewEmailView);
		}
	}
}