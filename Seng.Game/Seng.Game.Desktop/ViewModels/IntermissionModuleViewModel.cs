using System;
using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Linq;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Requests;
using Seng.Game.Desktop.Helpers.IntermissionModule;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel, INavigationAware
	{
		private IntermissionModuleDto intermissionModule;
		private bool isNavigationTarget = true;
		private int? currentVisibleIntermissionFrameId;

		private IntermissionFrameComponentDto currentFrame;
		private FrameType currentFrameType;

		public IntermissionFrameComponentDto CurrentFrame
		{
			get => currentFrame;
			set => SetProperty(ref currentFrame, value);
		}

		public FrameType CurrentFrameType
		{
			get => currentFrameType;
			set => SetProperty(ref currentFrameType, value);
		}

		public DelegateCommand NextFrameOrCloseCommand { get; set; }
		public DelegateCommand<OptionComponentDto> OptionSelectCommand { get; set; }

		public IntermissionModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			InitializeDelegateCommands();
			
			intermissionModule = GameState.IntermissionModule;
			currentVisibleIntermissionFrameId = intermissionModule.CurrentVisibleIntermissionFrameId;

			UpdateFrameContent();
		}

		private void InitializeDelegateCommands()
		{
			NextFrameOrCloseCommand = new DelegateCommand(NextFrameOrCloseCommandExecute);
			OptionSelectCommand = new DelegateCommand<OptionComponentDto>(OptionSelectCommandExecute);
		}

		private void OptionSelectCommandExecute(OptionComponentDto selectedOption)
		{
			var options = CurrentFrame.Question.Options.ToList();
			var selected = CurrentFrame.Question.Options.First(x => x == selectedOption);

			if (CurrentFrameType == FrameType.MultichoiceQuestion)
			{
				selected.Clicked = !selected.Clicked;
			}
			else
			{
				foreach (var option in options)
				{
					option.Clicked = false;
				}

				selected.Clicked = true;
			}

			NextFrameOrCloseCommand.RaiseCanExecuteChanged();
		}

		private bool CanNextFrameOrCloseCommandExecute()
		{
			switch (currentFrameType)
			{
				case FrameType.Question:
				case FrameType.MultichoiceQuestion:
				{
					return CurrentFrame.Question.Options.Any(x => x.Clicked);
				}
				case FrameType.UserInput:
					return currentFrame.UserInput != null;
				default: return true;
			}
		}

		private void NextFrameOrCloseCommandExecute()
		{
			if (CanNextFrameOrCloseCommandExecute())
			{
				var request = new GetModuleRequest<IntermissionModuleDto>
				{
					Module = intermissionModule,
					TriggeredComponentId = currentFrame.Button.ComponentId
				};
				GameState.IntermissionModule = GameState.Mediator.Send(request).Result;
				intermissionModule = GameState.IntermissionModule;
				currentVisibleIntermissionFrameId = intermissionModule.CurrentVisibleIntermissionFrameId;

				if (currentVisibleIntermissionFrameId == null)
				{
					isNavigationTarget = false;
					RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.GameView);
				}
				else
				{
					UpdateFrameContent();
				}
			}
		}

		private void UpdateFrameContent()
		{
			CurrentFrame = intermissionModule.Frames.First(x => x.Id == currentVisibleIntermissionFrameId);
			CurrentFrameType = (FrameType) Enum.Parse(typeof(FrameType), currentFrame.FrameType);
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedTo(NavigationContext navigationContext) { }
		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}