using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class InsertScenarioDataCommand : ICommand<CommandBasicResult>
    {
        public GameDbContext GameDbContext { get; set; }
    }
}
