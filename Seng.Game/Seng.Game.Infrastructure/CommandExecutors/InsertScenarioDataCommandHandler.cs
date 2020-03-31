using Dapper;
using Seng.Game.Business.Commands;
using Seng.Game.Infrastructure.BulkInsert;
using Seng.Game.Infrastructure.Database;
using Seng.Game.Infrastructure.SqlParametrizedQueries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    class InsertScenarioDataCommandHandler : ICommandHandler<InsertScenarioDataCommand, CommandBasicResult>
    {
        private IDbConnectionCreator _dbConnectionCreator;
        private IBulkInsertExecutor _bulkInsertExecutor;

        public InsertScenarioDataCommandHandler(IDbConnectionCreator dbConnectionCreator, IBulkInsertExecutor bulkInsertExecutor)
        {
            _dbConnectionCreator = dbConnectionCreator;
            _bulkInsertExecutor = bulkInsertExecutor;
        }

        public async Task<CommandBasicResult> Handle(InsertScenarioDataCommand command, CancellationToken cancellationToken)
        {
            using(var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.ModuleQuery, command.GameDbContext.Modules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.IntermissionModuleQuery, command.GameDbContext.IntermissionModules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.ButtonQuery, command.GameDbContext.Buttons, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.ComponentQuery, command.GameDbContext.Components, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.GameActionQuery, command.GameDbContext.GameActions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.OnClickOptionQuery, command.GameDbContext.OnClickOptions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.ContextQuery, command.GameDbContext.Contexts, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.IntermissionFrameQuery, command.GameDbContext.IntermissionFrames, dbConnection); 
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlQueries.SwitchIntermissionFrameActionQuery, command.GameDbContext.SwitchIntermissionFrameActions, dbConnection);
            }
            return new CommandBasicResult();
        }
    }
}
