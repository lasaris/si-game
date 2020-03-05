using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Seng.Game.Infrastructure.ApiClients;
using Seng.Game.Infrastructure.BulkInsert;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Seng.Game.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IBulkInsertExecutor, BulkInsertExecutor>();
            services.AddTransient<IDbConnectionCreator, SqliteConnectionFactory>();
            services.AddTransient<ISengWebApiClient, SengWebApiClient>();
        }
    }
}
