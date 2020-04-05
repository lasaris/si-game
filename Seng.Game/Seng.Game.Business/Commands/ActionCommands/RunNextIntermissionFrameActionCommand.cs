using Seng.Common.Entities;
using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class RunNextIntermissionFrameActionCommand : IActionCommand
    {
        public int GameActionId { get; set; }
    }
}
