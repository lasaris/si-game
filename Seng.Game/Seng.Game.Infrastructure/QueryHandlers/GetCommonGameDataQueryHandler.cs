using Dapper;
using MediatR;
using Seng.Common.Entities.Components;
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
    class GetCommonGameDataQueryHandler : IQueryHandler<GetCommonGameDataQuery, CommonGameData>
    {
        private const string SqlQuery = @"SELECT Id,
                                               MainVisibleModuleId
                                          FROM [module.CommonGameData];";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetCommonGameDataQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<CommonGameData> Handle(GetCommonGameDataQuery request, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                IEnumerable<CommonGameData> result = await dbConnection.QueryAsync<CommonGameData>(SqlQuery, request);
                return result == null ? new CommonGameData() : result.First();
            }
        }
    }
}
