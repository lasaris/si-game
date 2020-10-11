using Newtonsoft.Json;
using Seng.Common.Entities;
using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Actions.EmailModule;
using Seng.Common.Entities.Actions.IntermissionModule;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.Queries;
using Seng.Web.Business.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private GameDbContext MapWebDataToContext(ScenarioDataDto scenarioDataDto)
        {
            var webToDesktopDataConverter = new WebToDesktopDataConverter(scenarioDataDto);
            return webToDesktopDataConverter.Convert();
        }
    }
}
