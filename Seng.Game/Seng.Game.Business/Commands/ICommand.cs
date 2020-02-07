using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class ICommand<TResponse> where TResponse : IEntity
    {
    }
}
