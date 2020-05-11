using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs.Modules
{
    public interface IModuleDto
    {
        int ModuleId { get; set; }

        int NewMainVisibleModuleId { get; set; }

        IEnumerable<(int miliseconds, IEnumerable<ModuleType>)> AlertCollection { get; set; }
    }
}
