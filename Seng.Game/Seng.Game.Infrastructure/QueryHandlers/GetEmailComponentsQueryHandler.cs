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
    class GetEmailComponentsQueryHandler : IQueryHandler<GetEmailComponentsQuery, IEnumerable<EmailComponent>>
    {
        private const string SqlQuery = @"SELECT Sender,
                                            Subject,
                                            Date,
                                            ContentHeader,
                                            ContentFooter,
                                            ComponentId,
                                            IsSentEmail,
                                            EmailModuleId,
                                            Active
                                        FROM [component.EmailComponent]
                                        WHERE EmailModuleId = @EmailModuleId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetEmailComponentsQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<EmailComponent>> Handle(GetEmailComponentsQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<EmailComponent>(SqlQuery, query);
                return result == null ? new List<EmailComponent>() : result;
            }
        }
    }
}
