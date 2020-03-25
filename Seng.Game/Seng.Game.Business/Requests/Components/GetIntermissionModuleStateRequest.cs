using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.Common;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests.Components
{
    public class GetIntermissionModuleStateRequest : IRequest<IntermissionModuleDto>
    {
        public int TriggeredComponentId { get; set; }

        public IntermissionModuleDto Module { get; set; }
    }
}
