using MediatR;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class IQuery<TResponse> : IRequest<TResponse> 
        where TResponse : IEntity
    {
    }
}
