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
    class GetEmailComponentParagraphsQueryHandler : IQueryHandler<GetEmailComponentParagraphsQuery, IEnumerable<EmailComponentParagraph>>
    {
        private const string SqlQuery = @"SELECT Id,
                                               Content,
                                               EmailComponentId
                                          FROM [component.EmailComponentParagraph]
                                          WHERE EmailComponentId = @EmailComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetEmailComponentParagraphsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<EmailComponentParagraph>> Handle(GetEmailComponentParagraphsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<EmailComponentParagraph>(SqlQuery, query);
                return result == null ? new List<EmailComponentParagraph>() : result;
            }
        }
    }
}
