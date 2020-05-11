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
    class UpdateMainVisibleModuleActionCommandHandler : ICommandHandler<UpdateMainVisibleModuleActionCommand, bool>
    {
        private const string SqlQuery = @"UPDATE [module.CommonGameData]
                                   SET MainVisibleModuleId = @MainVisibleModuleId
                                   WHERE Id = 1";

        private IDbConnectionCreator _dbConnectionCreator;

        public UpdateMainVisibleModuleActionCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(UpdateMainVisibleModuleActionCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
