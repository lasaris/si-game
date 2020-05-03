using Seng.Common.Entities.Components.EmailModule;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetRecipientComponentsQueryHandler : IQueryHandler<GetRecipientComponentsQuery, IEnumerable<RecipientComponent>>
    {
        public Task<IEnumerable<RecipientComponent>> Handle(GetRecipientComponentsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
