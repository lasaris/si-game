using Newtonsoft.Json;
using Seng.Game.Business.Queries;
using Seng.Game.Infrastructure.ApiClients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class RetrieveScenarioFromServerQueryHandler : IQueryHandler<RetrieveScenarioFromServerQuery, bool>
    {
        private ISengWebApiClient _webApiClient;

        public RetrieveScenarioFromServerQueryHandler(ISengWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<bool> Handle(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            await _webApiClient.GetScenario(query, cancellationToken);
            //save it into database
            return true;
        }
    }
}
