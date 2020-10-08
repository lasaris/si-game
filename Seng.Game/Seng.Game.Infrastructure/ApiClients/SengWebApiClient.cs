using Newtonsoft.Json;
using Seng.Common.Entities;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.ApiClients
{
    class SengWebApiClient : ISengWebApiClient
    {
        public async Task<GameDbContext> GetScenario(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            using(var httpClient = new HttpClient())
            {
                //string webData = await httpClient.GetAsync()
                return JsonConvert.DeserializeObject<GameDbContext>(/*webData*/"");
            }
        }
    }
}
