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
    class MakeEmailActiveCommandHandler : ICommandHandler<MakeEmailActiveCommand, bool>
    {
        private const string SqlQuery = @"UPDATE [component.EmailComponent]
                                           SET Active = 1,
                                           Date = @Date
                                         WHERE ComponentId = @EmailComponentId";

        private IDbConnectionCreator _dbConnectionCreator;

        public MakeEmailActiveCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(MakeEmailActiveCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
