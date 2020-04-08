using MediatR;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests
{
    public class GetAllModuleBasicStatesRequest : IRequest<AllGameModulesBasicInfoDto>
    {
        public int GameId { get; set; } //currently unused, when multiple games will be possible for one database, use it here
    }
}
