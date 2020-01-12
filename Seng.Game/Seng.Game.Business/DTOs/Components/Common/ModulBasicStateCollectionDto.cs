using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Components.Common
{
    public class ModulBasicStateCollectionDto
    {
        public IEnumerable<ModulBasicStateDto> ModulsWithStates { get; set; }
    }
}
