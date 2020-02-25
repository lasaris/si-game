using MediatR;
using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class ICommand<TResponse> : IRequest<TResponse>
        where TResponse : IEntity
    {
    }
}
