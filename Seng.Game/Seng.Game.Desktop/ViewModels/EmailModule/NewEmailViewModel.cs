﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Desktop.Events;
using Seng.Game.Desktop.Helpers.EmailModule;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class NewEmailViewModel : BaseViewModel, INavigationAware
	{
		#region Fields

		private bool isNavigationTarget = true;
		private readonly NewEmailComponentDto newEmail;
		private RecipientComponentDto currentRecipient;
		private List<ParagraphComponentDto> currentParagraphOptions;

		private string subject;
		private string address;
		private string header;
		private ObservableCollection<ParagraphComponentDto> paragraphs = new ObservableCollection<ParagraphComponentDto>();
		private string footer;
		private bool isRecipientSelected;
		private bool isParagraphDisplayed;
		private bool isEmailCompleted;

		#endregion

		#region Properties

		public string Subject
		{
			get => subject;
			set
			{
				SetProperty(ref subject, value);
				SendEmailCommand.RaiseCanExecuteChanged();
			}
		}

		public string Address
		{
			get => address;
			set => SetProperty(ref address, value);
		}

		public string Header
		{
			get => header;
			set => SetProperty(ref header, value);
		}

		public ObservableCollection<ParagraphComponentDto> Paragraphs
		{
			get => paragraphs;
			set => SetProperty(ref paragraphs, value);
		}

		public string Footer
		{
			get => footer;
			set => SetProperty(ref footer, value);
		}

		public bool IsRecipientSelected
		{
			get => isRecipientSelected;
			set => SetProperty(ref isRecipientSelected, value);
		}

		public bool IsParagraphDisplayed
		{
			get => isParagraphDisplayed;
			set => SetProperty(ref isParagraphDisplayed, value);
		}

		public bool IsEmailCompleted
		{
			get => isEmailCompleted;
			set
			{
				SetProperty(ref isEmailCompleted, value);
				SendEmailCommand.RaiseCanExecuteChanged();
			}
		}

		#endregion

		#region Delegate Commands

		public DelegateCommand DiscardEmailCommand { get; set; }
		public DelegateCommand SelectRecipientCommand { get; set; }
		public DelegateCommand SelectParagraphCommand { get; set; }
		public DelegateCommand ChangeParagraphCommand { get; set; }
		public DelegateCommand RemoveParagraphCommand { get; set; }
		public DelegateCommand SendEmailCommand { get; set; }

		#endregion

		public NewEmailViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			newEmail = GameState.EmailModule.NewEmail;

			eventAggregator.GetEvent<ParagraphSelectionEvent>().Subscribe(HandleSelectedParagraph);
			eventAggregator.GetEvent<RecipientSelectionEvent>().Subscribe(HandleSelectedRecipient);

			InitializeDelegateCommands();

			SetInitialProperties();
		}

		#region Private Methods

		private void InitializeDelegateCommands()
		{
			DiscardEmailCommand = new DelegateCommand(DiscardEmailCommandExecute);
			SelectRecipientCommand = new DelegateCommand(SelectRecipientCommandExecute);
			SelectParagraphCommand = new DelegateCommand(SelectParagraphCommandExecute);
			ChangeParagraphCommand = new DelegateCommand(ChangeParagraphCommandExecute);
			RemoveParagraphCommand = new DelegateCommand(RemoveParagraphCommandExecute);
			SendEmailCommand = new DelegateCommand(SendEmailCommandExecute, CanSendEmailCommandExecute);
		}

		private void SetInitialProperties()
		{
			Subject = string.Empty;
			IsRecipientSelected = false;
			IsParagraphDisplayed = false;
			IsEmailCompleted = false;
		}

		private void HandleSelectedParagraph(ParagraphSelectionEventPayload payload)
		{
			if (payload.Purpose == ParagraphSelectionPurpose.Add)
			{
				if (Paragraphs.Count == 0)
				{
					IsParagraphDisplayed = true;
				}

				Paragraphs.Add(payload.Selected);
			}
			else
			{
				Paragraphs[Paragraphs.Count - 1] = payload.Selected;
			}

			if (payload.Selected.ChildrenParagraphs != null)
			{
				currentParagraphOptions = payload.Selected.ChildrenParagraphs.ToList();
			}
			else
			{
				IsEmailCompleted = true;
			}
		}

		private void HandleSelectedRecipient(RecipientComponentDto selectedRecipient)
		{
			if (currentRecipient != null)
			{
				newEmail.Recipients.First(x => x == currentRecipient).Selected = false;
			}

			selectedRecipient.Selected = true;

			IsRecipientSelected = true;
			currentRecipient = selectedRecipient;
			currentParagraphOptions = selectedRecipient.FirstParagraphs.ToList();
			Address = selectedRecipient.Address;
			Header = selectedRecipient.ContentHeader;
			Footer = selectedRecipient.ContentFooter;
		}

		private void DiscardEmailCommandExecute()
		{
			if (currentRecipient != null)
			{
				newEmail.Recipients.First(x => x == currentRecipient).Selected = false;
			}

			isNavigationTarget = false;

			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.EmptyEmailView);
		}

		private void SelectRecipientCommandExecute()
		{
			SetInitialProperties();

			Paragraphs.Clear();

			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.SelectOptionView,
				new NavigationParameters { { "Context", OptionsSelectionContext.Recipients } });
		}

		private void SelectParagraphCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.SelectOptionView,
				new NavigationParameters
				{
					{"Context", OptionsSelectionContext.Paragraphs},
					{"ParagraphOptions", currentParagraphOptions},
					{"Purpose", ParagraphSelectionPurpose.Add}
				});
		}

		private void ChangeParagraphCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.SelectOptionView,
				new NavigationParameters
				{
					{"Context", OptionsSelectionContext.Paragraphs},
					{"ParagraphOptions", currentParagraphOptions},
					{"Purpose", ParagraphSelectionPurpose.Change}
				});
		}

		private void RemoveParagraphCommandExecute()
		{
			Paragraphs.RemoveAt(Paragraphs.Count - 1);

			if (IsEmailCompleted)
			{
				IsEmailCompleted = false;
			}

			if (Paragraphs.Count == 0)
			{
				currentParagraphOptions = currentRecipient.FirstParagraphs.ToList();
				IsParagraphDisplayed = false;
			}
			else
			{
				currentParagraphOptions = Paragraphs[Paragraphs.Count - 1].ChildrenParagraphs.ToList();
			}
		}

		private bool CanSendEmailCommandExecute()
		{
			return isEmailCompleted && subject != string.Empty;
		}

		private void SendEmailCommandExecute()
		{
			isNavigationTarget = false;
			newEmail.Subject = subject;

			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.EmptyEmailView);
		}

		#endregion

		public void OnNavigatedTo(NavigationContext navigationContext) { }

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}