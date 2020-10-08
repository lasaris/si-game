using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class SwitchIntermissionFrameActionDto : ActionBaseDto
    {
        public int NewIntermissionFrame { get; set; }
        public int IntermissionModuleId { get; set; }
    }
}
