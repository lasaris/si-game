using Newtonsoft.Json;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.ApiClients
{
    class SengWebApiClient : ISengWebApiClient
    {
        public async Task<DbContext> GetScenario(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            string webData = await File.ReadAllTextAsync("example_scenario.json", cancellationToken);
            return JsonConvert.DeserializeObject<DbContext>(webData);
        }
    }
}
