using Dapper;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetWordsQueryHandler : IQueryHandler<GetWordsQuery, IEnumerable<WordComponent>>
    {
        private const string SqlQuery = @"SELECT
                                    Value,
                                    SearchingMinigameComponentId
                                    FROM [component.WordComponent]
                                    WHERE SearchingMinigameComponentId = @SearchingMinigameComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetWordsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<WordComponent>> Handle(GetWordsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<WordComponent>(SqlQuery, query);
                return result == null ? new List<WordComponent>() : result;
            }
        }
    }
}
