using Dapper;
using Seng.Common.Entities.Components;
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
    class GetButtonComponentQueryHandler : IQueryHandler<GetButtonComponentQuery, ButtonComponent>
    {
        private const string SqlQuery = @"SELECT
                                    Text,
                                    ComponentId
                                    FROM [component.ButtonComponent]
                                    WHERE ComponentId = @ButtonComponentId;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetButtonComponentQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<ButtonComponent> Handle(GetButtonComponentQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                IEnumerable<ButtonComponent> result = await dbConnection.QueryAsync<ButtonComponent>(SqlQuery, query);
                return result == null ? new ButtonComponent() : result.First();
            }
        }
    }
}
