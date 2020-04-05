using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public interface IActionCommand: ICommand<bool>
    {
        int GameActionId { get; set; }
    }
}
