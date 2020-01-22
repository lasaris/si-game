using MediatR;
using Seng.Game.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Requests.Components
{
    public class RunActionRequest : IRequest<GameDto>
    {
        public int TriggeredComponentId { get; set; }

        public GameDto CurrentGameState { get; set; }
    }
}
