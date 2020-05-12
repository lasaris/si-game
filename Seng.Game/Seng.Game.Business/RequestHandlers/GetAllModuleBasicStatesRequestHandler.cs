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
            var allGameModulesBasicInfo = new AllGameModulesBasicInfoDto();
            if (intermissionModule != null)
            {
                allGameModulesBasicInfo.IntermissionModuleInfo = new BasicModuleDto
                {
                    IsVisible = true,
                    ModuleId = intermissionModule.ModuleId
                };
            }
            var getEmailModuleQuery = new GetEmailModuleQuery() { ModuleId = 3 };
            EmailModule emailModule = await _mediator.Send(getEmailModuleQuery);
            if(emailModule != null)
            {
                allGameModulesBasicInfo.EmailModuleInfo = new BasicModuleDto
                {
                    IsVisible = true,
                    ModuleId = emailModule.ModuleId
                };
            }

            var getBrowserModuleQuery = new GetBrowserModuleQuery() { ModuleId = 4 } ;
            BrowserModule browserModule = await _mediator.Send(getBrowserModuleQuery);
            if (browserModule != null)
            {
                allGameModulesBasicInfo.BrowserModuleInfo = new BasicModuleDto
                {
                    IsVisible = true,
                    ModuleId = browserModule.ModuleId
                };
            }
            return allGameModulesBasicInfo;
        }
    }
}
