using MediatR;
using Seng.Game.Business.DTOs;
using Seng.Game.Business.DTOs.Components.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests.Components
{
    public class GetModuleAfterActionRequest<TModuleDto> : IRequest<ModuleAfterActionDto<TModuleDto>>
        where TModuleDto : BasicModuleDto
    {
        public int TriggeredComponentId { get; set; }

        public TModuleDto Module { get; set; }
    }
}
