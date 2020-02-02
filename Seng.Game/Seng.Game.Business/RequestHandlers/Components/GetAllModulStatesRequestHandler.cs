using MediatR;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.Requests.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers.Components
{
    class GetAllModulStatesRequestHandler : IRequestHandler<GetAllModulStatesRequest, ModulesBasicInfoDto>
    {
        public Task<ModulesBasicInfoDto> Handle(GetAllModulStatesRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new ModulesBasicInfoDto
            {
                Modules = new List<BasicComponentDto>
                {
                    
                }
            });
        }
    }
}
