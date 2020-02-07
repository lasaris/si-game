using Seng.Game.Business.Queries;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    public class GetActionByComponentQueryHandler : IQueryHandler<GetActionByComponentQuery, ActionInfo>
    {
        public ActionInfo Handle(GetActionByComponentQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
