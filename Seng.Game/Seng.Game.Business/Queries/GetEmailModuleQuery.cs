using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetEmailModuleQuery : IQuery<EmailModule>
    {
        public int ModuleId { get; set; }
    }
}
