using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class IQuery<TResponse> where TResponse : IEntity
    {
    }
}
