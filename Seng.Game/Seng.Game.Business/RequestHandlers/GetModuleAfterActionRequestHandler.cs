using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.Requests.Components;
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
        public Task<ModuleAfterActionDto<TModuleDto>> Handle(GetModuleAfterActionRequest<TModuleDto> request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new ModuleAfterActionDto<TModuleDto>
            {
                ModulesInfo = new ModulesInfoDto()
            });
        }

        //public Task<GameDto> Handle(RunActionRequest request, CancellationToken cancellationToken)
        //{
        //    return Task.Run(() => new GameDto
        //    {
        //        IntermissionModule = new IntermissionModuleDto
        //        {
        //            ComponentId = 1,
        //            IsRunning = true,
        //            IsVisible = true,
        //            Frames = new List<IntermissionFrameComponentDto>
        //            {
        //                new IntermissionFrameComponentDto
        //                {
        //                    ComponentId = 2,
        //                    IsRunning = true,
        //                    IsVisible = true,
        //                    TextParagraphs = new List<TextComponentDto>
        //                    {
        //                        new TextComponentDto
        //                        {
        //                            ComponentId = 3,
        //                            IsRunning = true,
        //                            IsVisible = true,
        //                            Text = "Hello, this is our demo game"
        //                        }
        //                    },
        //                    Button = new ButtonComponentDto
        //                    {
        //                        ComponentId = 4,
        //                        IsRunning = true,
        //                        IsVisible = true,
        //                        Text = "Next"
        //                    }
        //                }
        //            }
        //        }
        //    });
        //}
    }
}
