using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetIntermissionModuleQuery : IQuery<IntermissionModule>
    {
        public int ModuleId { get; set; }
    }
}
