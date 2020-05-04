using Dapper;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetParagraphComponentsQueryHandler : IQueryHandler<GetParagraphComponentsQuery, IEnumerable<ParagraphComponent>>
    {
        private const string SqlQuery = @"SELECT Id,
                                            Text,
                                            ParentParagraphId,
                                            ComponentId,
                                            RecipientComponentId
                                        FROM [component.ParagraphComponent]
                                        WHERE RecipientComponentId = @RecipientComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetParagraphComponentsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<ParagraphComponent>> Handle(GetParagraphComponentsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<ParagraphComponent>(SqlQuery, query);
                return result == null ? new List<ParagraphComponent>() : result;
            }
        }
    }
}
