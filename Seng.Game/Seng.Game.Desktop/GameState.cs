using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using MediatR;
using Prism.Events;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Requests;
using Seng.Game.Desktop.Events;
using Seng.Game.Desktop.Helpers;

namespace Seng.Game.Desktop
{
	public class GameState
	{
		private readonly IEventAggregator eventAggregator;
		public IMediator Mediator { get; }

		public AllGameModulesBasicInfoDto AllGameModulesBasicInfo { get; set; }

		public Dictionary<Guid, Alert> AlertsDictionary { get; set; } = new Dictionary<Guid, Alert>();

		public IntermissionModuleDto IntermissionModule { get; set; }

		public EmailModuleDto EmailModule { get; set; }

		public BrowserModuleDto BrowserModule { get; set; }

		public DesktopModuleDto DesktopModule { get; set; }

		public GameState(IEventAggregator ea)
		{
			eventAggregator = ea;

			Mediator = GameInitialize.GetMediator();

			AllGameModulesBasicInfo = GameInitialize.GetAllGameModulesBasicInfo(Mediator).Result;

			IntermissionModule = GameInitialize
				.InitializeIntermissionModule(Mediator, AllGameModulesBasicInfo.IntermissionModuleInfo.ModuleId).Result;
			EmailModule = GameInitialize
				.InitializeEmailModule(Mediator, AllGameModulesBasicInfo.EmailModuleInfo.ModuleId).Result;
			BrowserModule = GameInitialize
				.InitializeBrowserModule(Mediator, AllGameModulesBasicInfo.BrowserModuleInfo.ModuleId).Result;

			DesktopModule = GameInitialize.InitializeDesktopModule();

			CheckingForNewIntermissionModule();
		}

		public async Task UpdateIntermissionModule(int? triggeredComponentId = null)
		{
			var intermissionRequest = new GetModuleRequest<IntermissionModuleDto>
			{
				Module = new IntermissionModuleDto()
				{
					ModuleId = IntermissionModule.ModuleId
				},
				TriggeredComponentId = triggeredComponentId
			};

			var response = await Mediator.Send(intermissionRequest);

			CheckAlertCollection(response);

			IntermissionModule = response;
		}

		public async Task UpdateEmailModule(int? triggeredComponentId = null)
		{
			var emailRequest = new GetModuleRequest<EmailModuleDto>
			{
				Module = new EmailModuleDto()
				{
					ModuleId = EmailModule.ModuleId
				},
				TriggeredComponentId = triggeredComponentId
			};

			EmailModule = await Mediator.Send(emailRequest);
		}

		public async Task UpdateBrowserModule(int? triggeredComponentId = null)
		{
			var browserRequest = new GetModuleRequest<BrowserModuleDto>
			{
				Module = new BrowserModuleDto()
				{
					ModuleId = BrowserModule.ModuleId
				},
				TriggeredComponentId = triggeredComponentId
			};

			BrowserModule = await Mediator.Send(browserRequest);
		}

		private async void CheckingForNewIntermissionModule()
		{
			var timer = new Timer(5000);

			timer.Elapsed += async (sender, e) =>
			{
				var newIntermissionModuleId = AllGameModulesBasicInfo.IntermissionModuleInfo.NewMainVisibleModuleId;
				if (newIntermissionModuleId != 0)
				{
					IntermissionModule = await GameInitialize.InitializeIntermissionModule(Mediator, newIntermissionModuleId);
					eventAggregator.GetEvent<NewIntermissionModuleEvent>().Publish();
				}
			};
			timer.Enabled = true;

			AllGameModulesBasicInfo = await GameInitialize.GetAllGameModulesBasicInfo(Mediator);
		}

		private void CheckAlertCollection(IModuleDto module)
		{
			if (module.AlertCollection.Any())
			{
				foreach (var alert in module.AlertCollection)
				{
					foreach (var moduleType in alert.Item2)
					{
						SetAlert(alert.miliseconds, moduleType/*, message*/);
					}
				}
			}
		}

		private void SetAlert(int miliseconds, ModuleType moduleType)
		{
			Guid alertId = Guid.NewGuid();
			AlertsDictionary.Add(alertId, new Alert { /*Message = message,*/ ModuleType = moduleType });

			var timer = new Timer(miliseconds)
			{
				AutoReset = false
			};
			timer.Elapsed += (sender, e) => eventAggregator.GetEvent<AlertEvent>().Publish(new AlertEventPayload { AlertId = alertId });
			timer.Enabled = true;
		}
	}
}