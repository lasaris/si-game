﻿using Seng.Common.Entities.Modules;
using Seng.Game.Business.Queries;
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
