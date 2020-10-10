using Dapper;
using Seng.Common.Entities.Actions;
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
    class GetIntermissionFrameComponentsQueryHandler : IQueryHandler<GetIntermissionFrameComponentsQuery, IEnumerable<IntermissionFrameComponent>>
    {
        private const string SqlQuery = @"SELECT
                                    IntermissionModuleId,
                                    ButtonComponentId,
                                    TextParagraph,
                                    ComponentId,
                                    QuestionComponentId,
                                    FrameType
                                    FROM [component.IntermissionFrameComponent]
                                    WHERE IntermissionModuleId = @IntermissionModuleId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetIntermissionFrameComponentsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<IntermissionFrameComponent>> Handle(GetIntermissionFrameComponentsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<IntermissionFrameComponent>(SqlQuery, query);
                return result == null ? new List<IntermissionFrameComponent>() : result;
            }
        }
    }
}
