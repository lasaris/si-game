using System;
using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.Helpers.IntermissionModule;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel, INavigationAware
	{
		private bool isNavigationTarget = true;
		private readonly List<IntermissionFrameComponentDto> frames;
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
			
			var intermissionModule = GameState.IntermissionModule;
			frames = intermissionModule.Frames.ToList();
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
				//Temporary action call, will be replaced
				TemporaryActionCallSimulation();

				if (currentVisibleIntermissionFrameId == null)
				{
					isNavigationTarget = false;
					RegionManager.RequestNavigate(Regions.ApplicationRegion, Regions.GameView);
				}
				else
				{
					CurrentFrame = frames.First(x => x.Id == currentVisibleIntermissionFrameId);
					UpdateFrameContent();
				}
			}
		}

		/// <summary>
		/// Temporary, it will be deleted
		/// </summary>
		private void TemporaryActionCallSimulation()
		{
			if (currentFrame.ComponentId == 4)
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
			currentFrame = frames.First(x => x.Id == currentVisibleIntermissionFrameId);
			CurrentFrameType = (FrameType) Enum.Parse(typeof(FrameType), currentFrame.FrameType);
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => isNavigationTarget;

		public void OnNavigatedTo(NavigationContext navigationContext) { }
		public void OnNavigatedFrom(NavigationContext navigationContext) { }
	}
}