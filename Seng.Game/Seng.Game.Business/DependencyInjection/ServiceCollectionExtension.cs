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
            services.AddMediatRGenericHandlers<IntermissionModuleDto>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void AddMediatRGenericHandlers<TModuleDto>(this IServiceCollection services) where TModuleDto : BasicModuleDto
        {
            services.AddScoped(
                typeof(IRequestHandler<GetModuleAfterActionRequest<TModuleDto>, ModuleAfterActionDto<TModuleDto>>),
                typeof(GetModuleAfterActionRequestHandler<TModuleDto>));
        }
    }
}
