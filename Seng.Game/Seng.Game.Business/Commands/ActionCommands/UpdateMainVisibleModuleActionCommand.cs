using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class UpdateMainVisibleModuleActionCommand : ICommand<bool>
    {
        public int MainVisibleModuleId { get; set; }
    }
}
