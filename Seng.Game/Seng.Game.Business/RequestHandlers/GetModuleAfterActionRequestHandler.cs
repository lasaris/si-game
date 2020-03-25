using AutoMapper;
using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    public class GetModuleAfterActionRequestHandler : IRequestHandler<GetIntermissionModuleStateRequest, IntermissionModuleDto>
    {
        //private IMediator _mediator;
        //private IMapper _mapper;

        public GetModuleAfterActionRequestHandler(/*IMediator mediator, IMapper mapper*/)
        {
            //_mediator = mediator;
            //_mapper = mapper;
        }

        public async Task<IntermissionModuleDto> Handle(GetIntermissionModuleStateRequest request, CancellationToken cancellationToken)
        {
            //this will be the actual flow:
            //var getActionByComponentQuery = _mapper.Map<GetModuleAfterActionRequest<TModuleDto>, GetActionByComponentQuery>(request);
            //GameAction gameAction = await _mediator.Send(getActionByComponentQuery, cancellationToken);
            //Get action command by action type
            //run action command
            //GetBasicModuleStatesQuery
            //Get specific current module
            return null;
        }
    }
}
