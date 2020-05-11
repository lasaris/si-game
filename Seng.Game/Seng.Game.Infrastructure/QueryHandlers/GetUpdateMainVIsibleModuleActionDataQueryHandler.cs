using Dapper;
using Seng.Common.Entities.Actions;
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
    class GetUpdateMainVIsibleModuleActionDataQueryHandler : IQueryHandler<GetUpdateMainVIsibleModuleActionDataQuery, UpdateMainVIsibleModuleAction>
    {
        private const string SqlQuery = @"SELECT Id,
                                               ActionId,
                                               NewMainVisibleModuleId
                                          FROM [action.UpdateMainVisibleModuleAction];
                                          WHERE ActionId = @ActionId";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetUpdateMainVIsibleModuleActionDataQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }
        public async Task<UpdateMainVIsibleModuleAction> Handle(GetUpdateMainVIsibleModuleActionDataQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<UpdateMainVIsibleModuleAction>(SqlQuery, query);
                return result == null ? new UpdateMainVIsibleModuleAction() : result.FirstOrDefault();
            }
        }
    }
}
