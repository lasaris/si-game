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
    class InsertNewComponentCommandHandler : ICommandHandler<InsertNewComponentCommand, int>
    {
        private const string SqlQuery = @"INSERT INTO [component.Component] (
                                              Id
                                          )
                                          VALUES (
                                              @ComponentId
                                          );";

        private IDbConnectionCreator _dbConnectionCreator;

        public InsertNewComponentCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<int> Handle(InsertNewComponentCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return (int)_dbConnectionCreator.GetLastInsertedRowId(dbConnection);
            }
        }
    }
}
