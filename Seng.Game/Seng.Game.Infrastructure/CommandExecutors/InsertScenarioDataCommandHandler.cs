using Dapper;
using Seng.Game.Business.Commands;
using Seng.Game.Infrastructure.Database;
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
        IDbConnectionCreator _dbConnectionCreator;

        public InsertScenarioDataCommandHandler()
        {
            
        }

        public Task<CommandBasicResult> Handle(InsertScenarioDataCommand request, CancellationToken cancellationToken)
        {
            return null;
            //using(var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            //{
            //}
        }
    }
}
