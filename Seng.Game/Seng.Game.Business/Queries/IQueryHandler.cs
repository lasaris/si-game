using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public interface IQueryHandler<TQuery, TResponse> 
        where TQuery : IQuery<TResponse>
        where TResponse : IEntity
    {
        TResponse Handle(TQuery query);
    }
}
