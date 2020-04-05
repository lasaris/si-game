using Seng.Common.Entities.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetIntermissionFrameComponentsQuery : IQuery<IEnumerable<IntermissionFrameComponent>>
    {
        public int IntermissionModuleId { get; set; }
    }
}
