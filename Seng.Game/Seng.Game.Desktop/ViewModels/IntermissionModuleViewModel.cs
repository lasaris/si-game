using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Modules;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel, INavigationAware
	{
		private readonly IntermissionModuleDto intermissionModule;
		private readonly List<IntermissionFrameComponentDto> frames;
		private int? currentVisibleIntermissionFrameId;
		private bool isQuestionOnCurrentFrame;
		private bool isNavigationTarget = true;

		private IntermissionFrameComponentDto currentFrame;
		private string currentText;
		private QuestionComponentDto currentQuestion;

		public IntermissionFrameComponentDto CurrentFrame
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
			InitializeDelegateCommands();
			intermissionModule = GameState.IntermissionModule;
			frames = intermissionModule.Frames.ToList();

			currentVisibleIntermissionFrameId = intermissionModule.CurrentVisibleIntermissionFrameId;
			currentFrame = frames.First(x => x.ComponentId == currentVisibleIntermissionFrameId);
			UpdateFrameContent();
		}

		private void InitializeDelegateCommands()
		{
			NextFrameOrCloseCommand = new DelegateCommand(NextFrameOrCloseCommandExecute, CanNextFrameOrCloseCommandExecute);
			OptionSelectCommand = new DelegateCommand<OptionComponentDto>(OptionSelectCommandExecute);
			MultichoiceConfirmCommand = new DelegateCommand(MultichoiceConfirmCommandExecute);
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
			//Temporary action call, will be replaced
			TemporaryActionCallSimulation();
			
			if (currentVisibleIntermissionFrameId == null)
			{
				isNavigationTarget = false;
				RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.GameView);
			}
			else
			{
				CurrentFrame = frames.First(x => x.ComponentId == currentVisibleIntermissionFrameId);
				UpdateFrameContent();
			}
		}

		/// <summary>
		/// Temporary, it will be deleted
		/// </summary>
		private void TemporaryActionCallSimulation()
		{
			if (currentFrame.ComponentId == 3)
			{
				currentVisibleIntermissionFrameId = null;
			}
			else
			{
				currentVisibleIntermissionFrameId++;
			}
		}

		private void UpdateFrameContent()
		{
			CurrentText = CurrentFrame.TextParagraph;

			CurrentQuestion = CurrentFrame.Question;
			isQuestionOnCurrentFrame = CurrentQuestion != null;
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedTo(NavigationContext navigationContext) { }
		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}