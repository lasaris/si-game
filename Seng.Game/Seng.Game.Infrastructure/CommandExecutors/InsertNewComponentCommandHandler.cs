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
    class InsertNewComponentCommandHandler : ICommandHandler<InsertNewComponentCommand, bool>
    {
        private const string SqlQuery = @"INSERT INTO [component.Component] (
                                              Id
                                          )
                                          VALUES (
                                              @Id
                                          );";

        private IDbConnectionCreator _dbConnectionCreator;

        public InsertNewComponentCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(InsertNewComponentCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
