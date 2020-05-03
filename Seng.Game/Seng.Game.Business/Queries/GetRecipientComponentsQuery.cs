using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetRecipientComponentsQuery : IQuery<IEnumerable<RecipientComponent>>
    {
        public int EmailModuleId { get; set; }
    }
}
