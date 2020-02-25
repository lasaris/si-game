using MediatR;
using Newtonsoft.Json;
using Seng.Common.Entities;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.ApiClients;
using Seng.Game.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    internal class RetrieveScenarioFromServerQueryHandler : IQueryHandler<RetrieveScenarioFromServerQuery, GameDbContext>
    {
        private ISengWebApiClient _webApiClient;
        private IDbConnectionCreator _dbConnectionCreator { get; set; }

        public RetrieveScenarioFromServerQueryHandler(ISengWebApiClient webApiClient, IDbConnectionCreator dbConnectionFactory)
        {
            _webApiClient = webApiClient;
            _dbConnectionCreator = dbConnectionFactory;
        }

        public async Task<GameDbContext> Handle(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            await _webApiClient.GetScenario(query, cancellationToken);
            return null;
        }
    }
}
