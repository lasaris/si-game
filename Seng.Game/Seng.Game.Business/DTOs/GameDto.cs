using Seng.Game.Business.DTOs.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs
{
    public class GameDto
    {
        public IEnumerable<IntermissionModuleDto> IntermissionModules { get; set; }
    }
}
