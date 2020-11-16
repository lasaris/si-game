﻿using System;
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

            var retrieveScenarioRequest = new RetrieveScenarioRequest();
            RetrieveScenarioResultDto state = await mediator.Send(retrieveScenarioRequest);
        }
    }
}
