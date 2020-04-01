using AutoMapper;
using MediatR;
using Seng.Common.Entities;
using Seng.Game.Business.Commands;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class RetrieveScenarioRequestHandler : IRequestHandler<RetrieveScenarioRequest, RetrieveScenarioResultDto>
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public RetrieveScenarioRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<RetrieveScenarioResultDto> Handle(RetrieveScenarioRequest request, CancellationToken cancellationToken)
        {
            //RetrieveScenarioFromServerQuery query = _mapper.Map<RetrieveScenarioRequest, RetrieveScenarioFromServerQuery>(request);
            //GameDbContext gameDbContext = await _mediator.Send(query);
            //var insertScenarioDataCommand = new InsertScenarioDataCommand
            //{
            //    GameDbContext = gameDbContext
            //};
            //await _mediator.Send(insertScenarioDataCommand);

            GetActionByComponentQuery query2 = new GetActionByComponentQuery
            {
                ClickedComponentIds = new List<int>
                {
                    8, 9
                }.ToArray(),
                ComponentId = 1
            };
            var result =  await _mediator.Send(query2);

            return null;
        }
    }
}
