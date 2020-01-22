using MediatR;
using Seng.Game.Business.DTOs.Components.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests.Components
{
    public class GetAllModulStatesRequest : IRequest<ModulesBasicInfoDto>
    {
        public Guid GameId { get; set; }
    }
}
