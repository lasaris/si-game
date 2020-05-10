using AutoMapper;
using MediatR;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.Commands;
using Seng.Game.Business.Commands.ActionCommands;
using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Business.GameActionRunners;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.RequestHandlers
{
    class GetEmailModuleRequestHandler : GetModuleRequestHandler<EmailModuleDto>
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public GetEmailModuleRequestHandler(IMediator mediator, IGameActionFactory gameActionFactory, IMapper mapper) : base(mediator, gameActionFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            gameActionFactory.Register(GameActionType.SendEmailToPlayer, typeof(NextIntermissionFrameActionRunner));
        }

        protected override IEnumerable<int> GetClickedComponentIds(EmailModuleDto moduleDto)
        {
            return new List<int>();
        }

        protected override async Task<EmailModuleDto> RetrieveModule(int moduleId)
        {
            var getEmailModuleQuery = new GetEmailModuleQuery
            {
                ModuleId = moduleId
            };
            EmailModule emailModule = await _mediator.Send(getEmailModuleQuery);

            var getEmailComponentsQuery = new GetEmailComponentsQuery
            {
                EmailModuleId = emailModule.Id
            };
            IEnumerable<EmailComponent> emailComponents = await _mediator.Send(getEmailComponentsQuery);

            foreach(var email in emailComponents)
            {
                var getEmailParagraphsQuery = new GetEmailComponentParagraphsQuery
                {
                    EmailComponentId = email.Id
                };
                email.Paragraphs = await _mediator.Send(getEmailParagraphsQuery);
            }

            emailModule.RegularEmails = emailComponents.Where(email => !email.IsSentEmail);
            emailModule.SentEmails = emailComponents.Where(email => email.IsSentEmail);

            var getRecipientComponentsQuery = new GetRecipientComponentsQuery
            {
                EmailModuleId = emailModule.Id
            };
            IEnumerable<RecipientComponent> recipientComponents = await _mediator.Send(getRecipientComponentsQuery);
            emailModule.Recipients = recipientComponents;
            
            foreach(var recipient in emailModule.Recipients)
            {
                var getParagraphComponents = new GetNewEmailParagraphComponentsQuery
                {
                    RecipientComponentId = recipient.Id
                };
                IEnumerable<NewEmailParagraphComponent> paragraphComponents = await _mediator.Send(getParagraphComponents);
                recipient.FirstParagraphs = ComposeParagraphComponentsForest(paragraphComponents);
            }

            return _mapper.Map<EmailModule, EmailModuleDto>(emailModule);
        }

        protected override async Task UpdateDataBasedOnModuleState(EmailModuleDto moduleDto)
        {
            if(moduleDto == null || moduleDto.NewEmail == null)
            {
                return;
            }

            var insertComponentCommand = new InsertNewComponentCommand
            {
            };
            int componentId = await _mediator.Send(insertComponentCommand);

            var selectedRecipient = moduleDto.NewEmail.Recipients.Where(recipient => recipient.Selected).FirstOrDefault();

            if(selectedRecipient == default)
            {
                return;
            }
            List<string> contentParagraphs = new List<string>();
            var currentSelectedParagraph = selectedRecipient.FirstParagraphs.Where(paragraph => paragraph.Selected).FirstOrDefault();
            while(currentSelectedParagraph != null)
            {
                contentParagraphs.Add(currentSelectedParagraph.Text);
                currentSelectedParagraph = currentSelectedParagraph.ChildrenParagraphs?
                    .Where(paragraph => paragraph.Selected).FirstOrDefault();
            }

            var command = new CreateNewEmailCommand
            {
                Sender = selectedRecipient.Address,
                Subject = moduleDto.NewEmail.Subject,
                ContentFooter = selectedRecipient.ContentFooter,
                ContentHeader = selectedRecipient.ContentHeader,
                Date = DateTime.Now,
                EmailModuleId = moduleDto.EmailModuleId,
                ComponentId = componentId,
                IsSentEmail = true
            };

            int emailComponentId = await _mediator.Send(command);

            var addParagraphsCommand = new AddEmailComponentParagraphsCommand
            {
                EmailComponentId = emailComponentId,
                ContentParagraphs = contentParagraphs
            };
            await _mediator.Send(addParagraphsCommand);
        }

        private IEnumerable<NewEmailParagraphComponent> ComposeParagraphComponentsForest(IEnumerable<NewEmailParagraphComponent> paragraphComponents)
        {
            List<NewEmailParagraphComponent> recipientParagraphList = new List<NewEmailParagraphComponent>();
            Dictionary<int, List<NewEmailParagraphComponent>> childrenParagraphDict = new Dictionary<int, List<NewEmailParagraphComponent>>();
            foreach (var paragraphComponent in paragraphComponents)
            {
                if (paragraphComponent.ParentParagraphId == null)
                {
                    recipientParagraphList.Add(paragraphComponent);
                }
                else
                {
                    bool childrenAlreadyExist = childrenParagraphDict.TryGetValue(paragraphComponent.ParentParagraphId.Value, out var children);
                    if (childrenAlreadyExist)
                    {
                        children.Add(paragraphComponent);
                    }
                    else
                    {
                        children = new List<NewEmailParagraphComponent>
                            {
                                paragraphComponent
                            };
                        childrenParagraphDict.Add(paragraphComponent.ParentParagraphId.Value, children);
                    }
                }
            }

            foreach (var paragraphComponent in paragraphComponents)
            {
                bool hasChildren = childrenParagraphDict.TryGetValue(paragraphComponent.Id, out var children);
                if (hasChildren)
                {
                    paragraphComponent.ChildrenParagraphs = children;
                }
            }

            return recipientParagraphList;
        }
    }
}
