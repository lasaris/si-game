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
    class GetAddRecipientToNewEmailActionQueryHandler : IQueryHandler<GetAddRecipientToNewEmailActionQuery, AddRecipientToNewEmailAction>
    {
        private const string SqlQuery = @"SELECT ActionId,
                                               RecipientComponentId
                                          FROM [action.AddRecipientToNewEmailAction]
                                          WHERE ActionId = @GameActionId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetAddRecipientToNewEmailActionQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<AddRecipientToNewEmailAction> Handle(GetAddRecipientToNewEmailActionQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<AddRecipientToNewEmailAction>(SqlQuery, query);
                return result == null ? new AddRecipientToNewEmailAction() : result.FirstOrDefault();
            }
        }
    }
}
