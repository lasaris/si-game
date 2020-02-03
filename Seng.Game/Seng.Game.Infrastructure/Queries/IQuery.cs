using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.Queries
{
    public class IQuery<TResponse> where TResponse : IEntity
    {
    }
}
