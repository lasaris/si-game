using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DependencyInjection;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Requests;
using Seng.Game.Infrastructure.DependencyInjection;

namespace Seng.Game.Desktop
{
	public static class GameInitialize
	{
		public static IMediator GetMediator()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddInfrastructure();
			serviceCollection.AddBusiness();

			var serviceProvider = serviceCollection.BuildServiceProvider();

			return serviceProvider.GetService<IMediator>();
		}

		public static async Task<AllGameModulesBasicInfoDto> GetAllGameModulesBasicInfo(IMediator mediator)
		{
			var modulesStatesRequest = new GetAllModuleBasicStatesRequest();
			return await mediator.Send(modulesStatesRequest);
		}

		public static async Task<IntermissionModuleDto> InitializeIntermissionModule(IMediator mediator, int moduleId)
		{
			var intermissionRequest = new GetModuleRequest<IntermissionModuleDto>
			{
				Module = new IntermissionModuleDto()
				{
					ModuleId = moduleId
				},
				TriggeredComponentId = null
			};
			return await mediator.Send(intermissionRequest);
		}

		public static async Task<EmailModuleDto> InitializeEmailModule(IMediator mediator, int moduleId)
		{
			var emailRequest = new GetModuleRequest<EmailModuleDto>
			{
				Module = new EmailModuleDto()
				{
					ModuleId = moduleId
				},
				TriggeredComponentId = null
			};
			return await mediator.Send(emailRequest);
		}

		public static async Task<BrowserModuleDto> InitializeBrowserModule(IMediator mediator, int moduleId)
		{
			var browserRequest = new GetModuleRequest<BrowserModuleDto>
			{
				Module = new BrowserModuleDto()
				{
					ModuleId = moduleId
				},
				TriggeredComponentId = null
			};
			return await mediator.Send(browserRequest);
		}

		public static DesktopModuleDto InitializeDesktopModule()
		{
			return new DesktopModuleDto
			{
				IsVisible = true
			};
		}
	}
}