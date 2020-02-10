using Seng.Game.Business.Queries;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetBasicModuleStatesQueryHandler : IQueryHandler<GetBasicModuleStatesQuery, GameInstance>
    {
        public Task<GameInstance> Handle(GetBasicModuleStatesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
