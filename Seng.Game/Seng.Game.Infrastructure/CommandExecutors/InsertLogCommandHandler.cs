using Dapper;
using Seng.Game.Business.Commands;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    class InsertLogCommandHandler : ICommandHandler<InsertLogCommand, bool>
    {
        private const string SqlQueryInsertLog = @"INSERT INTO [history.Log] (
                                                      ComponentId
                                                  )
                                                  VALUES (
                                                      @ComponentId
                                                  );";

        private const string SqlQueryInsertClickedComponentsLog = @"INSERT INTO [history.ClickedComponentLog] (
                                                                          ClickedComponentId
                                                                      )
                                                                      VALUES (
                                                                          @ClickedComponents
                                                                      );";
        private readonly IDbConnectionCreator _dbConnectionCreator;

        public InsertLogCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(InsertLogCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateLogsNumber = await dbConnection.ExecuteAsync(SqlQueryInsertLog, command);
                await dbConnection.ExecuteAsync(SqlQueryInsertClickedComponentsLog, command);
                return updateLogsNumber > 0;
            }
        }
    }
}
