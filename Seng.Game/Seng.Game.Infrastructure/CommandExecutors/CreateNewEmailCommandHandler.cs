using Dapper;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    class CreateNewEmailCommandHandler : ICommandHandler<CreateNewEmailCommand, int>
    {
        private const string SqlQuery = @"INSERT INTO [component.EmailComponent] (
                                           Sender,
                                           Subject,
                                           Date,
                                           ContentHeader,
                                           ContentFooter,
                                           ComponentId,
                                           IsSentEmail,
                                           EmailModuleId
                                       )
                                       VALUES (
                                           @Sender,
                                           @Subject,
                                           @Date,
                                           @ContentHeader,
                                           @ContentFooter,
                                           @ComponentId,
                                           @IsSentEmail,
                                           @EmailModuleId
                                       );";

        private IDbConnectionCreator _dbConnectionCreator;

        public CreateNewEmailCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<int> Handle(CreateNewEmailCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return (int)_dbConnectionCreator.GetLastInsertedRowId(dbConnection);
            }
        }
    }
}
