using Newtonsoft.Json;
using Seng.Game.Business.Queries;
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
        public async Task<bool> Handle(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            string webData = await File.ReadAllTextAsync("example_scenario.json", cancellationToken);
            JsonConvert.DeserializeObject<DbContext>(webData);
            return true;
        }
    }
}
