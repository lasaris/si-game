using MediatR;
using Seng.Game.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests
{
    public class RetrieveScenarioRequest : IRequest<RetrieveScenarioResultDto>
    {
        public string GameToken { get; set; }
    }
}
