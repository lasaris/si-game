using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Desktop.Events;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class EmailModuleViewModel : BaseViewModel, INavigationAware
	{
		private EmailModuleDto emailModule;

		private ObservableCollection<EmailComponentDto> emailList = new ObservableCollection<EmailComponentDto>();
		private string activeEmailListName;

		public ObservableCollection<EmailComponentDto> EmailList
		{
			get => emailList;
			set => SetProperty(ref emailList, value);
		}

		public string ActiveEmailListName
		{
			get => activeEmailListName;
			set => SetProperty(ref activeEmailListName, value);
		}

		public DelegateCommand NewEmailCommand { get; set; }
		public DelegateCommand ShowInboxEmailsCommand { get; set; }
		public DelegateCommand ShowSentEmailsCommand { get; set; }
		public DelegateCommand<EmailComponentDto> ViewEmailFromListCommand { get; set; }

		public EmailModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			NewEmailCommand = new DelegateCommand(NewEmailCommandExecute);
			ShowInboxEmailsCommand = new DelegateCommand(ShowInboxEmailsCommandExecute);
			ShowSentEmailsCommand = new DelegateCommand(ShowSentEmailsCommandExecute);
			ViewEmailFromListCommand = new DelegateCommand<EmailComponentDto>(ViewEmailFromListCommandExecute);

			emailModule = gameState.EmailModule;

			EventAggregator.GetEvent<EmailSentEvent>().Subscribe(UpdateSentEmails);

			regionManager.RegisterViewWithRegion(Regions.EmailRegion, Regions.EmptyEmailViewType);
		}

		private void UpdateSentEmails()
		{
			emailModule = GameState.EmailModule;

			if (ActiveEmailListName == "Sent")
			{
				ShowSentEmailsCommandExecute();
			}
		}

		private void UpdateInboxEmails()
		{
			emailModule = GameState.EmailModule;

			if (ActiveEmailListName == "Inbox")
			{
				ShowInboxEmailsCommandExecute();
			}
		}

		private void ViewEmailFromListCommandExecute(EmailComponentDto email)
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.DisplayEmailView,
				new NavigationParameters { {"Email", email} });
		}

		private void ShowInboxEmailsCommandExecute()
		{
			EmailList.Clear();

			ActiveEmailListName = "Inbox";
			EmailList.AddRange(emailModule.RegularEmails);
		}

		private void ShowSentEmailsCommandExecute()
		{
			EmailList.Clear();

			ActiveEmailListName = "Sent";
			EmailList.AddRange(emailModule.SentEmails);
		}

		private void NewEmailCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.NewEmailView);
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			UpdateInboxEmails();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => true;

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}