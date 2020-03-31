using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.RequestHandlers;
using Seng.Game.Business.Requests.Components;
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
        }
    }
}
