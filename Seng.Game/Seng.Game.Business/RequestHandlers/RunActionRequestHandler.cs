using MediatR;
using Seng.Game.Business.DTOs;
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
    public class RunActionRequestHandler : IRequestHandler<RunActionRequest, GameDto>
    {
        public Task<GameDto> Handle(RunActionRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GameDto
            {
                IntermissionModules = new List<IntermissionModuleDto>
                {
                    new IntermissionModuleDto
                    {
                        ComponentId = 1,
                        ComponentName = "FirstInfo",
                        IsRunning = true,
                        IsVisible = true,
                        Frames = new List<IntermissionFrameComponentDto>
                        {
                            new IntermissionFrameComponentDto
                            {
                                ComponentId = 2,
                                ComponentName = "FirstFrame",
                                IsRunning = true,
                                IsVisible = true,
                                TextParagraphs = new List<TextComponentDto>
                                {
                                    new TextComponentDto
                                    {
                                        ComponentId = 3,
                                        IsRunning = true,
                                        IsVisible = true,
                                        Text = "Hello, this is our demo game"
                                    }
                                },
                                Button = new ButtonComponentDto
                                {
                                    ComponentId = 4,
                                    IsRunning = true,
                                    IsVisible = true,
                                    Text = "Next"
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}
