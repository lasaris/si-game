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
    class GetNewEmailParagraphComponentsQueryHandler : IQueryHandler<GetNewEmailParagraphComponentsQuery, IEnumerable<NewEmailParagraphComponent>>
    {
        private const string SqlQuery = @"SELECT Text,
                                            ParentParagraphId,
                                            ComponentId,
                                            RecipientComponentId
                                        FROM [component.NewEmailParagraphComponent]
                                        WHERE RecipientComponentId = @RecipientComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetNewEmailParagraphComponentsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<NewEmailParagraphComponent>> Handle(GetNewEmailParagraphComponentsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<NewEmailParagraphComponent>(SqlQuery, query);
                return result == null ? new List<NewEmailParagraphComponent>() : result;
            }
        }
    }
}
