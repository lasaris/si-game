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
    class GetIntermissionModuleStateQueryHandler : IQueryHandler<GetIntermissionModuleStateQuery, CommonGameData>
    {

        private const string SqlQuery = @"SELECT Id,
                                               MainVisibleModuleId
                                          FROM [module.CommonGameData]
                                          LIMIT 1;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetIntermissionModuleStateQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<CommonGameData> Handle(GetIntermissionModuleStateQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<CommonGameData>(SqlQuery, query);
                return result == null ? new CommonGameData() : result.FirstOrDefault();
            }
        }
    }
}
