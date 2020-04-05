using AutoMapper;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.MapperProfile
{
    class BusinessMapperProfile : Profile
    {
        public BusinessMapperProfile()
        {
            CreateMap<RetrieveScenarioRequest, RetrieveScenarioFromServerQuery>();
            CreateMap<IntermissionModule, IntermissionModuleDto>()
                .ForMember(dest => dest.CurrentVisibleIntermissionFrameId, opt => opt.MapFrom(src => src.CurrentlyVisibleFrameId))
                .ForMember(dest => dest.Frames, opt => opt.MapFrom(src => src.IntermissionFrameComponents))
                .ForMember(dest => dest.IsVisible, opt => opt.MapFrom(src => src.Module.IsVisible));
            CreateMap<IntermissionFrameComponent, IntermissionFrameComponentDto>()
                .ForMember(dest => dest.Button, opt => opt.MapFrom(src => src.ButtonComponent))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.QuestionComponent));
            CreateMap<ButtonComponent, ButtonComponentDto>();
            CreateMap<QuestionComponent, QuestionComponentDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.OptionComponents));
            CreateMap<OptionComponent, OptionComponentDto>();
        }
    }
}
