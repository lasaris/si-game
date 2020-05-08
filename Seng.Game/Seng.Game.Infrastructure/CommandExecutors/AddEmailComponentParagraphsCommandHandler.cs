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
    class AddEmailComponentParagraphsCommandHandler : ICommandHandler<AddEmailComponentParagraphsCommand, bool>
    {
        private const string SqlQuery = @"INSERT INTO [component.EmailComponentParagraph] (
                                                    Content,
                                                    EmailComponentId
                                                )
                                                VALUES(
                                                    @Content,
                                                    @EmailComponentId
                                                );";

        private IDbConnectionCreator _dbConnectionCreator;

        public AddEmailComponentParagraphsCommandHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<bool> Handle(AddEmailComponentParagraphsCommand command, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                foreach(var content in command.ContentParagraphs)
                {
                    await dbConnection.ExecuteAsync(SqlQuery, 
                        new 
                        {
                            Content = content,
                            command.EmailComponentId
                        });
                }
                return true;
            }
        }
    }
}
