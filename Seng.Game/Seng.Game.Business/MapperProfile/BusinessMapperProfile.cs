using AutoMapper;
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
        }
    }
}
