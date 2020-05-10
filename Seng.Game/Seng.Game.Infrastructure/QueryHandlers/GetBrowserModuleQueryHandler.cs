using Dapper;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetBrowserModuleQueryHandler : IQueryHandler<GetBrowserModuleQuery, BrowserModule>
    {
        private const string SqlQuery = @"SELECT
                                        bm.Id,
                                        bm.SearchingMinigameComponentId,
                                        bm.ModuleId,
                                        m.Id,
                                        m.IsVisible,
                                        smc.Id,
                                        smc.Solution,
                                        smc.IsCompleted,
                                        smc.Height,
                                        smc.Width,
                                        smc.ComponentId
                                        FROM [module.BrowserModule] bm
                                        INNER JOIN [module.Module] m ON bm.ModuleId = m.Id
                                        LEFT JOIN [component.SearchingMinigameComponent] smc ON bm.SearchingMinigameComponentId = smc.Id
                                        WHERE bm.ModuleId = @ModuleId";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetBrowserModuleQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<BrowserModule> Handle(GetBrowserModuleQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<BrowserModule, Module, SearchingMinigameComponent, BrowserModule>(
                    SqlQuery,
                    (browserModule, module, searchingMinigameComponent) =>
                    {
                        browserModule.SearchingMinigame = searchingMinigameComponent;
                        browserModule.Module = module;
                        return browserModule;
                    },
                    splitOn: "Id",
                    param: query
                    );
                return result == null ? new BrowserModule() : result.FirstOrDefault();
            }
        }
    }
}
