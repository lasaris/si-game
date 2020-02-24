using AutoMapper;
using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests.Components;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    public class GetModuleAfterActionRequestHandler<TModuleDto> : IRequestHandler<GetModuleAfterActionRequest<TModuleDto>, ModuleAfterActionDto<TModuleDto>>
        where TModuleDto : BasicModuleDto
    {
        //private IMediator _mediator;
        //private IMapper _mapper;

        public GetModuleAfterActionRequestHandler(/*IMediator mediator, IMapper mapper*/)
        {
            //_mediator = mediator;
            //_mapper = mapper;
        }

        public async Task<ModuleAfterActionDto<TModuleDto>> Handle(GetModuleAfterActionRequest<TModuleDto> request, CancellationToken cancellationToken)
        {
            //this will be the actual flow:
            //var getActionByComponentQuery = _mapper.Map<GetModuleAfterActionRequest<TModuleDto>, GetActionByComponentQuery>(request);
            //GameAction gameAction = await _mediator.Send(getActionByComponentQuery, cancellationToken);
            //Get action command by action type
            //run action command
            //GetBasicModuleStatesQuery
            //Get specific current module

            var module = new IntermissionModuleDto
            {
                ModuleId = 1,
                IsRunning = true,
                IsVisible = true,
                Frames = new List<IntermissionFrameComponentDto>
                    {
                        new IntermissionFrameComponentDto
                        {
                            ComponentId = 2,
                            TextParagraph = new TextComponentDto()
                            {
	                            ComponentId = 3,
	                            Text = "Hello, this is our demo game"
                            },
                            Button = new ButtonComponentDto
                            {
                                ComponentId = 4,
                                Text = "Next"
                            }
                        }
                    }
            };

            return await Task.Run(() => new ModuleAfterActionDto<TModuleDto>
            {
                ModulesInfo = new ModulesInfoDto
                {
                    Modules = new List<BasicModuleDto>
                    {
                        new BasicModuleDto
                        {
                            ModuleId = 1,
                            IsRunning = true,
                            IsVisible = false
                        }
                    }
                },
                CurrentModule = (TModuleDto)Convert.ChangeType(module, typeof(TModuleDto))
            });
        }
    }
}
