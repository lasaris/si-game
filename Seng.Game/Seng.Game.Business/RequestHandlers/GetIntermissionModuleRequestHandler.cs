﻿using AutoMapper;
using MediatR;
using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.GameActionRunners;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class GetIntermissionModuleRequestHandler : GetModuleRequestHandler<IntermissionModuleDto>
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public GetIntermissionModuleRequestHandler(IMediator mediator, IMapper mapper, IGameActionFactory gameActionFactory) : base(mediator, gameActionFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            gameActionFactory.Register(GameActionType.SwitchIntermissionFrame, typeof(NextIntermissionFrameActionRunner));
        }

        protected override IEnumerable<int> GetClickedComponentIds(IntermissionModuleDto moduleDto)
        {
            var clickedComponentIds = new List<int>();
            if(moduleDto.Frames == null)
            {
                return clickedComponentIds;
            }
            foreach(var frame in moduleDto.Frames)
            {
                if(frame.Question != null)
                {
                    foreach(var option in frame.Question.Options)
                    {
                        if (option.Clicked)
                        {
                            clickedComponentIds.Add(option.ComponentId);
                        }
                    }
                }
            }
            return clickedComponentIds;
        }

        protected override async Task<IntermissionModuleDto> RetrieveModule(int moduleId)
        {
            var getModuleQuery = new GetIntermissionModuleQuery
            {
                ModuleId = moduleId
            };
            IntermissionModule intermissionModule = await _mediator.Send(getModuleQuery);

            if (intermissionModule == null)
            {
                return null;
            }

            var getIntermissionFramesQuery = new GetIntermissionFrameComponentsQuery
            {
                IntermissionModuleId = intermissionModule.ModuleId
            };
            IEnumerable<IntermissionFrameComponent> intermissionFrames = await _mediator.Send(getIntermissionFramesQuery);
            intermissionModule.IntermissionFrameComponents = intermissionFrames;

            foreach (var intermissionFrame in intermissionFrames)
            {
                if(intermissionFrame.ButtonComponentId != null)
                {
                    var getButtonQuery = new GetButtonComponentQuery
                    {
                        ButtonComponentId = intermissionFrame.ButtonComponentId ?? default
                    };
                    ButtonComponent buttonComponent = await _mediator.Send(getButtonQuery);
                    intermissionFrame.ButtonComponent = buttonComponent;
                }

                if (intermissionFrame.QuestionComponentId != null)
                {
                    var getQuestionComponentQuery = new GetQuestionComponentQuery
                    {
                        QuestionComponentId = intermissionFrame.QuestionComponentId.Value
                    };
                    QuestionComponent questionComponent = await _mediator.Send(getQuestionComponentQuery);
                    intermissionFrame.QuestionComponent = questionComponent;

                    var getOptionsComponentQuery = new GetOptionComponentQuery
                    {
                        QuestionComponentId = intermissionFrame.QuestionComponentId.Value
                    };
                    IEnumerable<OptionComponent> optionComponents = await _mediator.Send(getOptionsComponentQuery);
                    intermissionFrame.QuestionComponent.OptionComponents = optionComponents;
                }
            };

            return _mapper.Map<IntermissionModule, IntermissionModuleDto>(intermissionModule);
        }

        protected override Task UpdateDataBasedOnModuleState(IntermissionModuleDto moduleDto)
        {
            return Task.CompletedTask;
        }
    }
}
