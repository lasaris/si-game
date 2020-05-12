using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.GameActionRunners;
using Seng.Game.Business.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Seng.Game.Business.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IGameActionFactory, GameActionFactory>();
            services.AddScoped<NextIntermissionFrameActionRunner>();
            services.AddScoped<SendEmailToPlayerActionRunner>();
            services.AddScoped<UpdateMainVIsibleModuleActionRunner>();
            services.AddScoped<IGameActionRunner, NextIntermissionFrameActionRunner>(s => s.GetService<NextIntermissionFrameActionRunner>());
            services.AddScoped<IGameActionRunner, SendEmailToPlayerActionRunner>(s => s.GetService<SendEmailToPlayerActionRunner>());
            services.AddScoped<IGameActionRunner, UpdateMainVIsibleModuleActionRunner>(s => s.GetService<UpdateMainVIsibleModuleActionRunner>());
        }
    }
}
