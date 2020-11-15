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
                                                      Id,
                                                      ComponentId
                                                  )
                                                  VALUES (
                                                      @ComponentId
                                                  );";

        private const string SqlQueryInsertClickedComponentsLog = @"INSERT INTO [history.ClickedComponentLog] (
                                                                          Id,
                                                                          ClickedComponentId
                                                                      )
                                                                      VALUES (
                                                                          @Id,
                                                                          @ClickedComponentId
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
                int updateLogsNumber = await dbConnection.ExecuteAsync(SqlQueryInsertLog, command.ComponentId);
                await dbConnection.ExecuteAsync(SqlQueryInsertClickedComponentsLog, command.ClickedComponents);
                return updateLogsNumber > 0;
            }
        }
    }
}
