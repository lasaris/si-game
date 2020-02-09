using MediatR;
using Seng.Game.Business.Queries;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    public class GetActionByComponentQueryHandler : IQueryHandler<GetActionByComponentQuery, ActionInfo>
    {
        public Task<ActionInfo> Handle(GetActionByComponentQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
