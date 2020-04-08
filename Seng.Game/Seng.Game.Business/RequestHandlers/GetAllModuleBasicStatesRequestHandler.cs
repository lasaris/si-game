using AutoMapper;
using MediatR;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class GetAllModuleBasicStatesRequestHandler : IRequestHandler<GetAllModuleBasicStatesRequest, AllGameModulesBasicInfoDto>
    {
        private IMediator _mediator;
        private IMapper _mapper;


        public GetAllModuleBasicStatesRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<AllGameModulesBasicInfoDto> Handle(GetAllModuleBasicStatesRequest request, CancellationToken cancellationToken)
        {
            var getIntermissionModuleQuery = new GetIntermissionModuleStateQuery();
            IntermissionModule intermissionModule = await _mediator.Send(getIntermissionModuleQuery);
            if(intermissionModule != null)
            {
                return new AllGameModulesBasicInfoDto
                {
                    IntermissionModuleInfo = new BasicModuleDto
                    {
                        IsVisible = true,
                        ModuleId = intermissionModule.ModuleId
                    }
                };
            }
            return new AllGameModulesBasicInfoDto
            {
                IntermissionModuleInfo = new BasicModuleDto
                {
                    IsVisible = false
                }
            };
        }
    }
}
