using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.Requests.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    public class RunActionRequestHandler : IRequestHandler<RunActionRequest, GameDto>
    {
        public Task<GameDto> Handle(RunActionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
