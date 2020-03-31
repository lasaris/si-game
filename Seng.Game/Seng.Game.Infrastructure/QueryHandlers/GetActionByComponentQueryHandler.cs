using MediatR;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seng.Common.Entities.Actions;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    public class GetActionByComponentQueryHandler : IQueryHandler<GetActionByComponentQuery, GameAction>
    {
        private const string SqlQuery = "";

        public Task<GameAction> Handle(GetActionByComponentQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
