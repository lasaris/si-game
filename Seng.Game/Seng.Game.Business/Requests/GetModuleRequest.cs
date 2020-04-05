using MediatR;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests
{
    public class GetModuleRequest<TModuleDto> : IRequest<TModuleDto>
        where TModuleDto : IModuleDto
    {
        public int TriggeredComponentId { get; set; }

        public TModuleDto Module { get; set; }
    }
}
