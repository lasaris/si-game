using System.Collections.Generic;
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
	public class SelectOptionViewModel : BaseViewModel, INavigationAware
	{
		private OptionsSelectionContext context;
		private ParagraphSelectionPurpose paragraphSelectionPurpose;
		private List<RecipientComponentDto> recipients;
		private List<ParagraphComponentDto> paragraphOptions;
		private int rows;
		private int columns;
		private List<string> source;

		public int Rows
		{
			get => rows;
			set => SetProperty(ref rows, value);
		}

		public int Columns
		{
			get => columns;
			set => SetProperty(ref columns, value);
		}

		public List<string> Source
		{
			get => source;
			set => SetProperty(ref source, value);
		}

		public DelegateCommand<string> SelectOptionCommand { get; set; }

		public SelectOptionViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,
			GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			SelectOptionCommand = new DelegateCommand<string>(SelectOptionCommandExecute);
		}

		private void SelectOptionCommandExecute(string selected)
		{
			switch (context)
			{
				case OptionsSelectionContext.Recipients:
					var selectedRecipient = recipients.First(x => x.Address == selected);
					EventAggregator.GetEvent<RecipientSelectionEvent>().Publish(selectedRecipient);
					break;
				case OptionsSelectionContext.Paragraphs:
				{
					ParagraphSelectionEventPayload paragraphSelectionEventPayload = new ParagraphSelectionEventPayload
					{
						Purpose = paragraphSelectionPurpose,
						ParagraphOptions = paragraphOptions,
						SelectedParagraph = paragraphOptions.First(x => x.Text == selected)
					};
					EventAggregator.GetEvent<ParagraphSelectionEvent>().Publish(paragraphSelectionEventPayload);
					break;
				}
			}

			RegionManager.RequestNavigate(Regions.EmailRegion, Regions.NewEmailView);
		}

		private void ComputeRowsAndColumns()
		{
			if (Source.Count <= 1)
			{
				Rows = 1;
				Columns = 1;
			}
			if (Source.Count <= 2)
			{
				Rows = 2;
				Columns = 1;
			} else if (Source.Count <= 4)
			{
				Rows = 2;
				Columns = 2;
			} else if (Source.Count <= 6)
			{
				Rows = 3;
				Columns = 2;
			} else if (Source.Count <= 8)
			{
				Rows = 4;
				Columns = 2;
			}
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			context = (OptionsSelectionContext) navigationContext.Parameters["Context"];

			switch (context)
			{
				case OptionsSelectionContext.Recipients:
					recipients = GameState.EmailModule.NewEmail.Recipients.ToList();
					Source = recipients.Select(x => x.Address).ToList();
					break;
				case OptionsSelectionContext.Paragraphs:
					paragraphOptions = (List<ParagraphComponentDto>) navigationContext.Parameters["ParagraphOptions"];
					paragraphSelectionPurpose = (ParagraphSelectionPurpose) navigationContext.Parameters["Purpose"];
					Source = paragraphOptions.Select(x => x.Text).ToList();
					break;
			}

			ComputeRowsAndColumns();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => false;

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}