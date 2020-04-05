using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.QueryResponseModels
{
    public class IntermissionModuleWithModule
    {
        public IntermissionModule IntermissionModule { get; set; }

        public Module Module { get; set; }
    }
}
