using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetEmailComponentsQuery : IQuery<IEnumerable<EmailComponent>>
    {
        public int EmailModuleId { get; set; }
    }
}
