using Seng.Common.Entities.Components.EmailModule;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetParagraphComponentsQueryHandler : IQueryHandler<GetParagraphComponentsQuery, IEnumerable<ParagraphComponent>>
    {
        public Task<IEnumerable<ParagraphComponent>> Handle(GetParagraphComponentsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
