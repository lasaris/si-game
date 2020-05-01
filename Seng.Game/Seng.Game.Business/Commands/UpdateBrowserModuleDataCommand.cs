using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class UpdateBrowserModuleDataCommand : ICommand<bool>
    {
        public int ModuleId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
