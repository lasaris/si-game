using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class DisplayEmailViewModel : BaseViewModel, INavigationAware
	{
		private EmailComponentDto email;

		private string subject;
		private string sender;
		private DateTime date;
		private string contentHeader;
		private List<string> paragraphs;
		private string contentFooter;

		public string Subject
		{
			get => subject;
			set => SetProperty(ref subject, value);
		}

		public string Sender
		{
			get => sender;
			set => SetProperty(ref sender, value);
		}

		public DateTime Date
		{
			get => date;
			set => SetProperty(ref date, value);
		}

		public string ContentHeader
		{
			get => contentHeader;
			set => SetProperty(ref contentHeader, value);
		}

		public List<string> Paragraphs
		{
			get => paragraphs;
			set => SetProperty(ref paragraphs, value);
		}

		public string ContentFooter
		{
			get => contentFooter;
			set => SetProperty(ref contentFooter, value);
		}

		public DisplayEmailViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
		}

		private void InitializeProperties()
		{
			Subject = email.Subject;
			Sender = email.Sender;
			Date = email.Date;
			ContentHeader = email.ContentHeader;
			Paragraphs = email.Paragraphs.ToList();
			ContentFooter = email.ContentFooter;
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			email = (EmailComponentDto) navigationContext.Parameters["Email"];

			InitializeProperties();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => false;

		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}