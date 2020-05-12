using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class MakeEmailActiveCommand : ICommand<bool>
    {
        public int EmailComponentId { get; set; }
    }
}
