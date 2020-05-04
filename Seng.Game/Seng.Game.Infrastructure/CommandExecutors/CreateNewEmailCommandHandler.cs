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
    class CreateNewEmailCommandHandler : ICommandHandler<CreateNewEmailCommand, bool>
    {
        private const string SqlQuery = @"INSERT INTO [component.EmailComponent] (
                                           Sender,
                                           Subject,
                                           Date,
                                           ContentHeader,
                                           ContentFooter,
                                           ComponentId,
                                           IsSentEmail,
                                           EmailModuleId,
                                           Content
                                       )
                                       VALUES (
                                           @Sender,
                                           @Subject,
                                           @Date,
                                           @ContentHeader,
                                           @ContentFooter,
                                           @ComponentId,
                                           @IsSentEmail,
                                           @EmailModuleId,
                                           @Content
                                       );";

        private IDbConnectionCreator _dbConnectionCreator;

        public CreateNewEmailCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(CreateNewEmailCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                int updateRowsNumber = await dbConnection.ExecuteAsync(SqlQuery, command);
                return updateRowsNumber > 0;
            }
        }
    }
}
