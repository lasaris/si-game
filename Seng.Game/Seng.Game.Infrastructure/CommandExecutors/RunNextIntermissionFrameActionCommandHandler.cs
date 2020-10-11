using Seng.Game.Business.Commands;
using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seng.Common.Entities.Modules;
using Seng.Game.Infrastructure.Database;
using Dapper;
using Seng.Game.Business.Commands.ActionCommands;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    class RunNextIntermissionFrameActionCommandHandler : ICommandHandler<RunNextIntermissionFrameActionCommand, bool>
    {
        private const string SqlQuery = @"UPDATE [module.IntermissionModule]
                                        SET 
                                            CurrentlyVisibleFrameId = (SELECT NewIntermissionFrameComponentId 
                                                                        FROM [action.SwitchIntermissionFramesAction] a 
                                                                        WHERE a.ActionId = @GameActionId)
                                        WHERE EXISTS (SELECT a.ActionId 
                                                        FROM [action.SwitchIntermissionFramesAction] a 
                                                        WHERE a.ActionId = @GameActionId
                                                        AND [module.IntermissionModule].Id = a.IntermissionModuleId);";

        private IDbConnectionCreator _dbConnectionCreator;

        public RunNextIntermissionFrameActionCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(RunNextIntermissionFrameActionCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
