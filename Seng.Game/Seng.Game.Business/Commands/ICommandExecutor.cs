using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public interface ICommandExecutor<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : IEntity
    {
        TResponse Execute(TCommand command);
    }
}
