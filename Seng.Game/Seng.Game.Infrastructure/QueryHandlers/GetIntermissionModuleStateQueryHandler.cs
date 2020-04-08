using Dapper;
using Seng.Common.Entities.Modules;
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
    class GetIntermissionModuleStateQueryHandler : IQueryHandler<GetIntermissionModuleStateQuery, IntermissionModule>
    {

        private const string SqlQuery = @"SELECT
                                        im.Id,
                                        im.ModuleId,
                                        im.CurrentlyVisibleFrameId,
                                        m.Id,
                                        m.IsVisible
                                        FROM [module.IntermissionModule] im
                                        INNER JOIN [module.Module] m
                                        LIMIT 1;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetIntermissionModuleStateQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IntermissionModule> Handle(GetIntermissionModuleStateQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<IntermissionModule, Module, IntermissionModule>(
                    SqlQuery,
                    (intermissionModule, module) =>
                    {
                        intermissionModule.Module = module;
                        return intermissionModule;
                    },
                    splitOn: "Id",
                    param: query
                    );
                return result == null ? new IntermissionModule() : result.FirstOrDefault();
            }
        }
    }
}
