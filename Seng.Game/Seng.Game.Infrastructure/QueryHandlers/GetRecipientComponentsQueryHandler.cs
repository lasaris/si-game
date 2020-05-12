using Dapper;
using Seng.Common.Entities.Components.EmailModule;
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
    class GetRecipientComponentsQueryHandler : IQueryHandler<GetRecipientComponentsQuery, IEnumerable<RecipientComponent>>
    {
        private const string SqlQuery = @"SELECT Id,
                                               ComponentId,
                                               Address,
                                               Description,
                                               ContentHeader,
                                               ContentFooter,
                                               EmailModuleId,
                                               ButtonComponentId
                                          FROM [component.RecipientComponent]
                                          WHERE EmailModuleId = @EmailModuleId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetRecipientComponentsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<RecipientComponent>> Handle(GetRecipientComponentsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<RecipientComponent>(SqlQuery, query);
                return result == null ? new List<RecipientComponent>() : result;
            }
        }
    }
}
