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
    class UpdateBrowserModuleDataCommandHandler : ICommandHandler<UpdateBrowserModuleDataCommand, bool>
    {
        private const string SqlQuery = @"UPDATE [component.SearchingMinigameComponent]
                                        SET 
                                            IsCompleted = @IsCompleted
                                        WHERE EXISTS (SELECT bm.ModuleId 
                                                        FROM [module.BrowserModule] bm
                                                        INNER JOIN [component.SearchingMinigameComponent] smc 
                                                        ON smc.ComponentId = bm.SearchingMinigameComponentId
                                                        WHERE bm.ModuleId = @ModuleId);";

        private IDbConnectionCreator _dbConnectionCreator;

        public UpdateBrowserModuleDataCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(UpdateBrowserModuleDataCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
