using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel, INavigationAware
	{
		private readonly List<IntermissionFrameComponentDto> frames;
		private int currentFrame;
		private bool isQuestionOnCurrentFrame;
		private bool isNavigationTarget = true;

		private List<TextComponentDto> currentTexts;
		private List<QuestionComponentDto> currentQuestions;

		public List<TextComponentDto> CurrentTexts
		{
			get => currentTexts;
			set => SetProperty(ref currentTexts, value);
		}

		public bool IsQuestionOnCurrentFrame
		{
			get => isQuestionOnCurrentFrame;
			set => SetProperty(ref isQuestionOnCurrentFrame, value);
		}

		public List<QuestionComponentDto> CurrentQuestions
		{
			get => currentQuestions;
			set => SetProperty(ref currentQuestions, value);
		}

		public DelegateCommand NextFrameOrCloseCommand { get; set; }

		public DelegateCommand<OptionComponentDto> AnswerSelectCommand { get; set; }

		public IntermissionModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			frames = GameState.IntermissionModule.Frames.ToList();

			UpdateFrameContent();

			NextFrameOrCloseCommand = new DelegateCommand(NextFrameOrCloseCommandExecute, CanNextFrameOrCloseCommandExecute);
			AnswerSelectCommand = new DelegateCommand<OptionComponentDto>(AnswerSelectCommandExecute);
		}

		private void AnswerSelectCommandExecute(OptionComponentDto selectedAnswer)
		{
			// Manipulate with selected answer

			NextFrameOrCloseCommandExecute();
		}
		 
		private bool CanNextFrameOrCloseCommandExecute()
		{
			return !IsQuestionOnCurrentFrame;
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
				currentFrame += 1;
				UpdateFrameContent();
			}
		}

		private void UpdateFrameContent()
		{
			CurrentTexts = frames[currentFrame].TextParagraphs == null
				? new List<TextComponentDto>()
				: frames[currentFrame].TextParagraphs.ToList();

			if (frames[currentFrame].Questions != null)
			{
				IsQuestionOnCurrentFrame = true;
				CurrentQuestions = frames[currentFrame].Questions.ToList();
			}
			else
			{
				IsQuestionOnCurrentFrame = false;
			}
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedTo(NavigationContext navigationContext) { }
		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}