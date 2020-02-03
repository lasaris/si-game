using Seng.Game.Entities;
using Seng.Game.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    public interface ICommandExecutor
    {
        IEntity Execute(ICommand command);
    }
}
