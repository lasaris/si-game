using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Regions;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel, INavigationAware
	{
		private readonly List<IntermissionFrameComponentDto> frames;
		private bool isQuestionOnCurrentFrame;
		private bool isNavigationTarget = true;

		private int currentFrame;
		private string currentText;
		private QuestionComponentDto currentQuestion;

		public int CurrentFrame
		{
			get => currentFrame;
			set => SetProperty(ref currentFrame, value);
		}

		public string CurrentText
		{
			get => currentText;
			set => SetProperty(ref currentText, value);
		}

		public QuestionComponentDto CurrentQuestion
		{
			get => currentQuestion;
			set => SetProperty(ref currentQuestion, value);
		}

		public DelegateCommand NextFrameOrCloseCommand { get; set; }
		public DelegateCommand<OptionComponentDto> OptionSelectCommand { get; set; }
		public DelegateCommand MultichoiceConfirmCommand { get; set; }

		public IntermissionModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			frames = GameState.IntermissionModule.Frames.ToList();

			UpdateFrameContent();

			NextFrameOrCloseCommand = new DelegateCommand(NextFrameOrCloseCommandExecute, CanNextFrameOrCloseCommandExecute);
			OptionSelectCommand = new DelegateCommand<OptionComponentDto>(OptionSelectCommandExecute);
			MultichoiceConfirmCommand = new DelegateCommand(MultichoiceConfirmCommandExecute);

			CurrentFrame = 0;
		}

		private void MultichoiceConfirmCommandExecute()
		{
			NextFrameOrCloseCommandExecute();
		}

		private void OptionSelectCommandExecute(OptionComponentDto selectedOption)
		{
			var option = currentQuestion.Options.First(x => x == selectedOption);

			if (currentQuestion.Multichoice)
			{
				option.Clicked = !option.Clicked;
			}
			else
			{
				option.Clicked = true;

				NextFrameOrCloseCommandExecute();
			}
		}
		 
		private bool CanNextFrameOrCloseCommandExecute()
		{
			return !isQuestionOnCurrentFrame;
		}

		private void NextFrameOrCloseCommandExecute()
		{
			var lastFrame = currentFrame + 1 == frames.Count;

			if (lastFrame)
			{
				isNavigationTarget = false;
				RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.GameView);
			}
			else
			{
				CurrentFrame += 1;
				UpdateFrameContent();
			}
		}

		private void UpdateFrameContent()
		{
			CurrentText = frames[currentFrame].TextParagraph;

			CurrentQuestion = frames[currentFrame].Question;
			isQuestionOnCurrentFrame = CurrentQuestion != null;
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedTo(NavigationContext navigationContext) { }
		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}