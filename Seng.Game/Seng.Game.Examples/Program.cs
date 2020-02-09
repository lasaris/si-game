using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DependencyInjection;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.Requests.Components;

namespace Seng.Game.Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //dependency injection configuration
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBusiness();

            //resolve manually dependency injection
            //you should probably do this automatically
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //resolve mediator
            //this should be done through constructor injection automatically
            IMediator mediator = serviceProvider.GetService<IMediator>();

            //creating request and fetching data
            //this is the way you should call Business layer
            var runActionRequest = new GetModuleAfterActionRequest<IntermissionModuleDto>
            {
                Module = new IntermissionModuleDto(),
                TriggeredComponentId = 4
            };
            ModuleAfterActionDto<IntermissionModuleDto> gameState = await mediator.Send(runActionRequest);
            Console.WriteLine(gameState.CurrentModule.GetType());
        }
    }
}
