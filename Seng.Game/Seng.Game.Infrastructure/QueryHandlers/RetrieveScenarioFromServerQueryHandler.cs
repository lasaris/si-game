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

        public RetrieveScenarioFromServerQueryHandler(ISengWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<GameDbContext> Handle(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            return await _webApiClient.GetScenario(query, cancellationToken);
        }
    }
}
