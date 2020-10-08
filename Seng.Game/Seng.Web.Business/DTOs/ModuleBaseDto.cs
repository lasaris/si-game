using Seng.Web.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class ModuleBaseDto : IModuleDto
    {
        public int ModuleId { get; set; }
    }
}
