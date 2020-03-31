using Seng.Common.Entities;
using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class RunNextIntermissionFrameActionCommand : ICommand<bool>
    {
        public int IntermissionModuleId { get; set; }

        public int NewVisibleFrameId { get; set; }
    }
}
