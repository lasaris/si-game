using AutoMapper;
using MediatR;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class GetBrowserModuleRequestHandler : GetModuleRequestHandler<BrowserModuleDto>
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public GetBrowserModuleRequestHandler(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        protected override IDictionary<string, Func<BrowserModuleDto, IActionCommand>> ActionCommandResolver { get; }

        protected override IEnumerable<int> GetClickedComponentIds(BrowserModuleDto moduleDto)
        {
            return new List<int>();
        }

        protected override async Task<BrowserModuleDto> RetrieveModule(int moduleId)
        {
            var getBrowserModuleQuery = new GetBrowserModuleQuery
            {
                ModuleId = moduleId
            };
            BrowserModule browserModule = await _mediator.Send(getBrowserModuleQuery);
            if(browserModule != null && browserModule.SearchingMinigame != null)
            {
                var getWordsQuery = new GetWordsQuery
                {
                    SearchingMinigameComponentId = browserModule.SearchingMinigame.Id
                };
                browserModule.SearchingMinigame.Words = await _mediator.Send(getWordsQuery);
            }
            return _mapper.Map<BrowserModule, BrowserModuleDto>(browserModule);
        }

        protected override async Task UpdateDataBasedOnModuleState(BrowserModuleDto moduleDto)
        {
            if(moduleDto != null && moduleDto.SearchingMinigame != null)
            {
                var command = new UpdateBrowserModuleDataCommand
                {
                    ModuleId = moduleDto.ModuleId,
                    IsCompleted = moduleDto.SearchingMinigame.IsCompleted
                };
                await _mediator.Send(command);
            }
        }
    }
}
