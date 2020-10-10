using Newtonsoft.Json;
using Seng.Common.Entities;
using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.Queries;
using Seng.Web.Business.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.ApiClients
{
    class SengWebApiClient : ISengWebApiClient
    {
        public async Task<GameDbContext> GetScenario(RetrieveScenarioFromServerQuery query, CancellationToken cancellationToken)
        {
            using(var httpClient = new HttpClient())
            {
                //string webData = await httpClient.GetAsync()
                return JsonConvert.DeserializeObject<GameDbContext>(/*webData*/"");
            }
        }

        private GameDbContext MapWebDataToContext(ScenarioDataDto scenarioDataDto)
        {
            var gameDbContext = new GameDbContext();
            gameDbContext.Modules = new List<Module>();
            gameDbContext.GameActions = new List<GameAction>();
            gameDbContext.Components = new List<Component>();
            gameDbContext.IntermissionModules = scenarioDataDto.IntermissionModules?.Select(intermissionModule => new IntermissionModule
            {
                CurrentlyVisibleFrameId = intermissionModule.CurrentIntermissionFrameId,
                ModuleId = intermissionModule.ModuleId,
                IntermissionFrameComponents = intermissionModule.IntermissionFrames?.Select(intermissionFrame => new IntermissionFrameComponent
                {
                    TextParagraph = intermissionFrame.Text,
                    ButtonComponent = intermissionFrame.Buttons?.Select(button => new ButtonComponent
                    {
                        ComponentId = button.ComponentId,
                        Text = button.ButtonText
                    }).FirstOrDefault(),
                    ButtonComponentId = intermissionFrame.Buttons?.Select(button => button.ComponentId).FirstOrDefault() ?? default,
                    ComponentId = intermissionFrame.ComponentId,
                    FrameType = intermissionFrame.FrameType,
                    IntermissionModuleId = intermissionModule.ModuleId,
                    QuestionComponent = intermissionFrame.Questions?.Select(question => new QuestionComponent
                    {
                        ComponentId = question.ComponentId,
                        OptionComponents = question.Options?.Select(option => new OptionComponent
                        {
                            ComponentId = option.ComponentId,
                            QuestionComponentId = question.ComponentId
                        })
                    }).FirstOrDefault(),
                    QuestionComponentId = intermissionFrame.Questions?.Select(question => question.ComponentId)
                         .FirstOrDefault() ?? default
                })
                .ToList()
            }).ToList();

            gameDbContext.EmailModules = scenarioDataDto.EmailModules?.Select(emailModule => new EmailModule
            {
                NewEmailSubject = emailModule.NewEmailSubject,
                ModuleId = emailModule.ModuleId,
                SentEmails = emailModule.SentEmails?.Select(sentEmail => new EmailComponent
                {
                    Sender = sentEmail.Sender,
                    Subject = sentEmail.Subject,
                    IsSentEmail = true,
                    Active = sentEmail.Active,
                    ComponentId = sentEmail.ComponentId,
                    ContentFooter = sentEmail.ContentFooter,
                    ContentHeader = sentEmail.ContentHeader,
                    Date = sentEmail.Date,
                    Paragraphs = sentEmail.EmailParagraphs?.Select(paragraph => new EmailComponentParagraph
                    {
                        Content = paragraph,
                        EmailComponentId = sentEmail.ComponentId
                    })
                }),
                RegularEmails = emailModule.ReceivedEmails?.Select(receivedEmail => new EmailComponent
                {
                    Sender = receivedEmail.Sender,
                    Subject = receivedEmail.Subject,
                    IsSentEmail = false,
                    Active = receivedEmail.Active,
                    ComponentId = receivedEmail.ComponentId,
                    ContentFooter = receivedEmail.ContentFooter,
                    ContentHeader = receivedEmail.ContentHeader,
                    Date = receivedEmail.Date,
                    Paragraphs = receivedEmail.EmailParagraphs?.Select(paragraph => new EmailComponentParagraph
                    {
                        Content = paragraph,
                        EmailComponentId = receivedEmail.ComponentId
                    })
                }),
                Recipients = emailModule.Recipients?.Select(recipient => new RecipientComponent
                {
                    Active = recipient.Active,
                    Address = recipient.Address,
                    ComponentId = recipient.ComponentId,
                    ContentFooter = recipient.ContentFooter,
                    ContentHeader = recipient.ContentHeader,
                    Description = recipient.Description,
                    ButtonComponent = recipient.Buttons?.Select(button => new ButtonComponent
                    {
                        ComponentId = button.ComponentId,
                        Text = button.ButtonText
                    }).FirstOrDefault(),
                    ButtonComponentId = recipient.Buttons?.Select(button => button.ComponentId)
                        .FirstOrDefault() ?? default,
                    FirstParagraphs = recipient.FirstParagraphs?.Select(firstParagraph => ConvertNewEmailParagraph(firstParagraph, null, recipient.ComponentId))
                })
            }).ToList();

            gameDbContext.BrowserModules = scenarioDataDto.BrowserModules?.Select(browserModule => new BrowserModule
            {
                SearchingMinigame = browserModule.SearchingMinigames.Select(searchingMinigame => new SearchingMinigameComponent
                {
                    Solution = searchingMinigame.Solution,
                    ComponentId = searchingMinigame.ComponentId,
                    Height = searchingMinigame.Height,
                    IsCompleted = false,
                    Width = searchingMinigame.Width,
                    Words = searchingMinigame.Words.Select(word => new WordComponent
                    {
                        SearchingMinigameComponentId = searchingMinigame.ComponentId,
                        ComponentId = word.ComponentId
                    })
                }).FirstOrDefault(),
                SearchingMinigameComponentId = browserModule.SearchingMinigames?.Select(searchingMinigame => searchingMinigame.ComponentId)
                    .FirstOrDefault() ?? default,
                ModuleId = browserModule.ModuleId
            }).ToList();

            return gameDbContext;
        }

        private NewEmailParagraphComponent ConvertNewEmailParagraph(NewEmailParagraphComponentDto webParagraph, int? parentParagraphId, int recipientParagraphId)
        {
            return new NewEmailParagraphComponent
            {
                ChildrenParagraphs = webParagraph?.ChildrenParagraphs?
                //TODO - find out, whether recipient paragraph id should be everywhere, or only in root component
                    .Select(childrenParagraph => ConvertNewEmailParagraph(childrenParagraph, webParagraph.ComponentId, recipientParagraphId)),
                ComponentId = webParagraph.ComponentId,
                ParentParagraphId = parentParagraphId,
                RecipientComponentId = recipientParagraphId,
                Text = webParagraph.Text
            };
        }
    }
}
