using MediatR;
using Seng.Game.Entities;

namespace Seng.Game.Business.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : IEntity
    {
    }
}
