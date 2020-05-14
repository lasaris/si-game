using Dapper;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    class MakeRecipientActiveCommandHandler : ICommandHandler<MakeRecipientActiveCommand, bool>
    {
        private const string SqlQuery = @"UPDATE [component.RecipientComponent]
                                           SET Active = 1
                                         WHERE Id = @RecipientId";

        private IDbConnectionCreator _dbConnectionCreator;

        public MakeRecipientActiveCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(MakeRecipientActiveCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
