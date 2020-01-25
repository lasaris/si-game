using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        }

    }
}
