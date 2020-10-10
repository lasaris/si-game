using Dapper;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetEmailModuleQueryHandler : IQueryHandler<GetEmailModuleQuery, EmailModule>
    {
        private const string SqlQuery = @"SELECT
                                        em.ModuleId,
                                        em.NewEmailSubject,
                                        m.Id,
                                        m.IsVisible
                                        FROM [module.EmailModule] em
                                        INNER JOIN [module.Module] m ON em.ModuleId = m.Id
                                        WHERE em.ModuleId = @ModuleId";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetEmailModuleQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<EmailModule> Handle(GetEmailModuleQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                var result = await dbConnection.QueryAsync<EmailModule, Module, EmailModule>(
                    SqlQuery,
                    (emailModule, module) =>
                    {
                        emailModule.Module = module;
                        return emailModule;
                    },
                    splitOn: "Id",
                    param: query
                    );
                return result == null ? new EmailModule() : result.FirstOrDefault();
            }
        }
    }
}
