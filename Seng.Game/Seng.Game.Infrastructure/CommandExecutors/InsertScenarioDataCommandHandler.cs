using Dapper;
using Seng.Game.Business;
using Seng.Game.Business.Commands;
using Seng.Game.Infrastructure.BulkInsert;
using Seng.Game.Infrastructure.Database;
using Seng.Game.Infrastructure.SqlParametrizedQueries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
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
            File.Copy(Configurations.EmptyDbPath, Configurations.StaticDbPath, overwrite: true);
            using(var dbConnection = _dbConnectionCreator.CreateOpenConnection(Configurations.StaticConnectionString))
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
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.CommonGameDataCommand, command.GameDbContext.CommonGameData, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.EmailModuleCommand, command.GameDbContext.EmailModules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.BrowserModuleCommand, command.GameDbContext.BrowserModules, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.SearchingMinigameComponentCommand, command.GameDbContext.SearchingMinigameComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.WordComponentCommand, command.GameDbContext.WordComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.EmailComponentCommand, command.GameDbContext.EmailComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.EmailComponentParagraphCommand, command.GameDbContext.EmailComponentParagraphs, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.NewEmailParagraphComponentCommand, command.GameDbContext.NewEmailParagraphComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.RecipientComponentCommand, command.GameDbContext.RecipientComponents, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.UpdateMainVisibleModuleActionCommand, command.GameDbContext.UpdateMainVisibleModuleActions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.AddRecipientToNewEmailActionCommand, command.GameDbContext.AddRecipientToNewEmailActions, dbConnection);
                await _bulkInsertExecutor.ExecuteAsync(BasicInsertSqlCommands.SendEmailToPlayerActionCommand, command.GameDbContext.SendEmailToPlayerActions, dbConnection);
            }
            File.Copy(Configurations.StaticDbPath, Configurations.DbPath, overwrite: true);
            return new CommandBasicResult();
        }
    }
}
