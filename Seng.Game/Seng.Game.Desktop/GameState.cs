using System.Windows.Markup;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DependencyInjection;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Requests;
using Seng.Game.Infrastructure.DependencyInjection;

namespace Seng.Game.Desktop
{
	public class GameState
	{
		public IMediator Mediator { get; }

		public IntermissionModuleDto IntermissionModule { get; set; }

		public EmailModuleDto EmailModule { get; set; }

		public BrowserModuleDto BrowserModule { get; set; }

		public DesktopModuleDto DesktopModule { get; set; }

		public GameState()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddInfrastructure();
			serviceCollection.AddBusiness();

			var serviceProvider = serviceCollection.BuildServiceProvider();
			Mediator = serviceProvider.GetService<IMediator>();

			var modulesStatesRequest = new GetAllModuleBasicStatesRequest();
			AllGameModulesBasicInfoDto moduleStates = Mediator.Send(modulesStatesRequest).Result;

			var intermissionRequest = new GetModuleRequest<IntermissionModuleDto>
			{
				Module = new IntermissionModuleDto()
				{
					ModuleId = 1
				},
				TriggeredComponentId = null//1
			};
			IntermissionModuleDto intermissionModule = Mediator.Send(intermissionRequest).Result;

			var emailRequest = new GetModuleRequest<EmailModuleDto>
			{
				Module = new EmailModuleDto()
				{
					ModuleId = 2
				},
				TriggeredComponentId = null//1
			};
			EmailModuleDto emailModule = Mediator.Send(emailRequest).Result;

			IntermissionModule = intermissionModule;
			EmailModule = emailModule;
			BrowserModule = GameInitialize.BrowserModuleGet();
			DesktopModule = GameInitialize.DesktopModuleGet();
		}
	}
}