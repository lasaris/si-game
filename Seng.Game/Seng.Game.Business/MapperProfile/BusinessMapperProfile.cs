using AutoMapper;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Components;
using Seng.Game.Business.DTOs.Components.BrowserModule;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using Seng.Game.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<EmailModule, EmailModuleDto>()
                .ForMember(dest => dest.EmailModuleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NewEmail, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.IsVisible, opt => opt.MapFrom(src => src.Module.IsVisible));
            CreateMap<EmailModule, NewEmailComponentDto>()
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.NewEmailSubject))
                .ForMember(dest => dest.Recipients, opt => opt.MapFrom(src => src.Recipients));
            CreateMap<EmailComponent, EmailComponentDto>()
                .ForMember(dest => dest.Paragraphs, opt => opt.MapFrom(src => src.Paragraphs.Select(c => c.Content)));
            CreateMap<RecipientComponent, RecipientComponentDto>();
            CreateMap<NewEmailParagraphComponent, ParagraphComponentDto>();
            CreateMap<BrowserModule, BrowserModuleDto>()
                .ForMember(dest => dest.IsVisible, opt => opt.MapFrom(src => src.Module.IsVisible));
            CreateMap<SearchingMinigameComponent, SearchingMinigameComponentDto>();
            CreateMap<Module, BasicModuleDto>();
        }
    }
}
