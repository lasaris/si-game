using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetBrowserModuleQuery : IQuery<BrowserModule>
    {
        public int ModuleId { get; set; }
    }
}
