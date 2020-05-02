using MediatR;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class GetEmailModuleRequestHandler : GetModuleRequestHandler<EmailModuleDto>
    {
        protected override IDictionary<string, Func<EmailModuleDto, IActionCommand>> ActionCommandResolver =>
            new Dictionary<string, Func<EmailModuleDto, IActionCommand>>
            {
            };

        public GetEmailModuleRequestHandler(IMediator mediator) : base(mediator)
        {

        }

        protected override IEnumerable<int> GetClickedComponentIds(EmailModuleDto moduleDto)
        {
            return new List<int>();
        }

        protected override Task<EmailModuleDto> RetrieveModule(int moduleId)
        {
            throw new NotImplementedException();
        }

        protected override Task UpdateDataBasedOnModuleState(EmailModuleDto moduleDto)
        {
            return Task.CompletedTask;
        }
    }
}
