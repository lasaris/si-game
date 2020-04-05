using Dapper;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetOptionComponentQueryHandler : IQueryHandler<GetOptionComponentQuery, IEnumerable<OptionComponent>>
    {
        private const string SqlQuery = @"SELECT
                                        Id,
                                        ComponentId,
                                        Text,
                                        QuestionComponentId
                                        FROM[component.OptionComponent]
                                        WHERE QuestionComponentId = @QuestionComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetOptionComponentQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<OptionComponent>> Handle(GetOptionComponentQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<OptionComponent>(SqlQuery, query);
                return result == null ? new List<OptionComponent>() : result;
            }
        }
    }
}
