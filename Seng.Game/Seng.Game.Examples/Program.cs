using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DependencyInjection;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Requests;
using Seng.Game.Infrastructure.DependencyInjection;

namespace Seng.Game.Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //dependency injection configuration
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddInfrastructure();
            serviceCollection.AddBusiness();

            //resolve manually dependency injection
            //you should probably do this automatically
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //resolve mediator
            //this should be done through constructor injection automatically
            IMediator mediator = serviceProvider.GetService<IMediator>();

            //var retrieveScenarioRequest = new RetrieveScenarioRequest
            //{
            //    GameToken = "abcd"
            //};
            //RetrieveScenarioResultDto state = await mediator.Send(retrieveScenarioRequest);

            //creating request and fetching data
            //this code below is the way you should call Business layer
            
            //basic module states request
            var modulesStatesRequest = new GetAllModuleBasicStatesRequest();
            AllGameModulesBasicInfoDto moduleStates = await mediator.Send(modulesStatesRequest);

            var intermissionModule = new IntermissionModuleDto
            {
                ModuleId = moduleStates.IntermissionModuleInfo.ModuleId
            };
            
            var getModuleRequest = new GetModuleRequest<IntermissionModuleDto>
            {
                TriggeredComponentId = null,
                Module = intermissionModule
            };
            intermissionModule = await mediator.Send(getModuleRequest);
            
            intermissionModule.Frames.First().Question.Options.First().Clicked = true;
            getModuleRequest.TriggeredComponentId = 1;
            getModuleRequest.Module = intermissionModule;
            intermissionModule = await mediator.Send(getModuleRequest);

            getModuleRequest.TriggeredComponentId = 2;
            getModuleRequest.Module = intermissionModule;
            intermissionModule = await mediator.Send(getModuleRequest);

            getModuleRequest.TriggeredComponentId = 3;
            getModuleRequest.Module = intermissionModule;
            intermissionModule = await mediator.Send(getModuleRequest);

            Console.WriteLine(intermissionModule.GetType());


        }
    }
}
