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
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.ModuleCommand, command.GameDbContext.Modules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.IntermissionModuleCommand, command.GameDbContext.IntermissionModules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.ButtonComponentCommand, command.GameDbContext.ButtonComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.ComponentCommand, command.GameDbContext.Components, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.GameActionCommand, command.GameDbContext.GameActions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.OnClickOptionCommand, command.GameDbContext.OnClickOptions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.ContextCommand, command.GameDbContext.Contexts, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.IntermissionFrameComponentCommand, command.GameDbContext.IntermissionFrameComponents, dbConnection); 
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.SwitchIntermissionFrameActionCommand, command.GameDbContext.SwitchIntermissionFrameActions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.QuestionComponentCommand, command.GameDbContext.QuestionComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.OptionComponentCommand, command.GameDbContext.OptionComponents, dbConnection);
            }
            return new CommandBasicResult();
        }
    }
}
