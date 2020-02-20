using Seng.Common.Entities.Modules;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetBasicModuleStatesQueryHandler : IQueryHandler<GetBasicModuleStatesQuery, IEnumerable<Module>>
    {
        public Task<IEnumerable<Module>> Handle(GetBasicModuleStatesQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
