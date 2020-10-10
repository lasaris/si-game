using Dapper;
using Seng.Common.Entities.Components.IntermissionModule;
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
    class GetQuestionComponentQueryHandler : IQueryHandler<GetQuestionComponentQuery, QuestionComponent>
    {
        private const string SqlQuery = @"SELECT
                                    ComponentId,
                                    Text
                                    FROM [component.QuestionComponent]
                                    WHERE ComponentId = @QuestionComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetQuestionComponentQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<QuestionComponent> Handle(GetQuestionComponentQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<QuestionComponent>(SqlQuery, query);
                return result == null ? new QuestionComponent() : result.FirstOrDefault();
            }
        }
    }
}
