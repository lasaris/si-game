using Dapper;
using Seng.Common.Entities.Actions.EmailModule;
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
    class GetSendEmailToPlayerActionDataQueryHandler : IQueryHandler<GetSendEmailToPlayerActionDataQuery, SendEmailToPlayerAction>
    {
        private const string SqlQuery = @"SELECT Id,
                                                 EmailComponentId
                                        FROM [action.SendEmailToPlayerAction]
                                        WHERE Id = @GameActionId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetSendEmailToPlayerActionDataQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<SendEmailToPlayerAction> Handle(GetSendEmailToPlayerActionDataQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<SendEmailToPlayerAction>(SqlQuery, query);
                return result == null ? new SendEmailToPlayerAction() : result.FirstOrDefault();
            }
        }
    }
}
