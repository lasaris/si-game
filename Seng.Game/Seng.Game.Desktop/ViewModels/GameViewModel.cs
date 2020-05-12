using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Desktop.Events;
using Seng.Game.Desktop.Helpers;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class GameViewModel : BaseViewModel
	{
		private readonly AllGameModulesBasicInfoDto allGameModulesBasicInfo;

		private bool isDesktopButtonChecked;

		public bool IsDesktopButtonChecked
		{
			get => isDesktopButtonChecked;
			set => SetProperty(ref isDesktopButtonChecked, value);
		}

		private string emailModuleTooltipMessage;
		public string EmailModuleTooltipMessage
		{
			get => emailModuleTooltipMessage;
			set => SetProperty(ref emailModuleTooltipMessage, value);
		}

		private bool isEmailModuleTooltipEnabled;
		public bool IsEmailModuleTooltipEnabled
		{
			get => isEmailModuleTooltipEnabled;
			set => SetProperty(ref isEmailModuleTooltipEnabled, value);
		}

		private bool isIntermissionButtonShowed;

		public bool IsIntermissionButtonShowed
		{
			get => isIntermissionButtonShowed;
			set => SetProperty(ref isIntermissionButtonShowed, value);
		}

		public bool IsBrowserModuleVisible => allGameModulesBasicInfo.BrowserModuleInfo.IsVisible;
		public bool IsEmailModuleVisible => allGameModulesBasicInfo.EmailModuleInfo.IsVisible;

		public DelegateCommand<string> ModuleNavigateCommand { get; set; }
		public DelegateCommand ShowIntermissionCommand { get; set; }

		public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			allGameModulesBasicInfo = GameState.AllGameModulesBasicInfo;

			EventAggregator.GetEvent<AlertEvent>().Subscribe(OnAlertEvent);
			EventAggregator.GetEvent<NewIntermissionModuleEvent>().Subscribe(OnNewIntermissionModuleEvent);

			ModuleNavigateCommand = new DelegateCommand<string>(ModuleNavigateCommandExecute);
			ShowIntermissionCommand = new DelegateCommand(ShowIntermissionCommandExecute);

			if (GameState.DesktopModule.IsVisible)
			{
				IsDesktopButtonChecked = true;
				regionManager.RegisterViewWithRegion(Regions.ModuleRegion, Regions.DesktopModuleViewType);
			}
		}

		private void ModuleNavigateCommandExecute(string moduleView)
		{
			DisableAlertTooltip(moduleView);

			RegionManager.RequestNavigate(Regions.ModuleRegion, moduleView);
		}

		private void ShowIntermissionCommandExecute()
		{
			IsIntermissionButtonShowed = false;
			ShowIntermission();
		}

		private void OnNewIntermissionModuleEvent()
		{
			IsIntermissionButtonShowed = true;
		}

		private void OnAlertEvent(AlertEventPayload payload)
		{
			var alert = GameState.AlertsDictionary[payload.AlertId];

			EnableAlertTooltip(alert.ModuleType, alert.Message);
			GameState.AlertsDictionary.Remove(payload.AlertId);
		}

		private void EnableAlertTooltip(ModuleType alertModuleType, string alertMessage)
		{
			switch (alertModuleType)
			{
				case ModuleType.EmailModule:
				{
					IsEmailModuleTooltipEnabled = true;
					EmailModuleTooltipMessage = alertMessage;
					break;
				}
			}
		}

		private void DisableAlertTooltip(string moduleView)
		{
			switch (moduleView)
			{
				case "EmailModuleView":
				{
					IsEmailModuleTooltipEnabled = false;
					break;
				}
			}
		}
	}
}