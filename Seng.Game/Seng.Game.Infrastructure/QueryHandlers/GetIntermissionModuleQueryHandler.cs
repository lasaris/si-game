using Seng.Game.Business.Queries;
using Seng.Game.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetIntermissionModuleQueryHandler : IQueryHandler<GetIntermissionModuleQuery, IntermissionModule>
    {
        public Task<IntermissionModule> Handle(GetIntermissionModuleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
