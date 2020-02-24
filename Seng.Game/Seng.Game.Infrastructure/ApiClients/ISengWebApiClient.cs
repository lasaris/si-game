using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.ApiClients
{
    interface ISengWebApiClient
    {
        Task<DbContext> GetScenario(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken);
    }
}
