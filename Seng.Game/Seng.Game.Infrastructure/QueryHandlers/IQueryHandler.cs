using Seng.Game.Entities;
using Seng.Game.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResponse> 
        where TQuery : IQuery<TResponse>
        where TResponse : IEntity
    {
        TResponse Handle(TQuery query);
    }
}
