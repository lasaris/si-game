
using Seng.Common.Entities;
using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Actions.EmailModule;
using Seng.Common.Entities.Actions.IntermissionModule;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Web.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Seng.Game.Infrastructure
{
    class WebToDesktopDataConverter
    {
        private ScenarioDataDto _scenarioDataDto;
        private GameDbContext _gameDbContext { get; }
        private int currentOnClickOptionId = 1;
        private int currentContextId = 1;
        private int emailComponentParagraphId = 1;

        public WebToDesktopDataConverter(ScenarioDataDto scenarioDataDto)
        {
            _scenarioDataDto = scenarioDataDto;
            _gameDbContext = new GameDbContext();
            _gameDbContext.SwitchIntermissionFrameActions = new List<SwitchIntermissionFrameAction>();
            _gameDbContext.Contexts = new List<Context>();
            _gameDbContext.GameActions = new List<GameAction>();
            _gameDbContext.OnClickOptions = new List<OnClickOption>();
            _gameDbContext.IntermissionFrameComponents = new List<IntermissionFrameComponent>();
            _gameDbContext.ButtonComponents = new List<ButtonComponent>();
            _gameDbContext.Components = new List<Component>();
            _gameDbContext.IntermissionModules = new List<IntermissionModule>();
            _gameDbContext.Modules = new List<Module>();
            _gameDbContext.QuestionComponents = new List<QuestionComponent>();
            _gameDbContext.OptionComponents = new List<OptionComponent>();
            _gameDbContext.CommonGameData = new List<CommonGameData>();
            _gameDbContext.EmailModules = new List<EmailModule>();
            _gameDbContext.BrowserModules = new List<BrowserModule>();
            _gameDbContext.SearchingMinigameComponents = new List<SearchingMinigameComponent>();
            _gameDbContext.WordComponents = new List<WordComponent>();
            _gameDbContext.EmailComponents = new List<EmailComponent>();
            _gameDbContext.EmailComponentParagraphs = new List<EmailComponentParagraph>();
            _gameDbContext.NewEmailParagraphComponents = new List<NewEmailParagraphComponent>();
            _gameDbContext.RecipientComponents = new List<RecipientComponent>();
            _gameDbContext.UpdateMainVisibleModuleActions = new List<UpdateMainVIsibleModuleAction>();
            _gameDbContext.AddRecipientToNewEmailActions = new List<AddRecipientToNewEmailAction>();
            _gameDbContext.SendEmailToPlayerActions = new List<SendEmailToPlayerAction>();
        }

        public GameDbContext Convert()
        {
            _gameDbContext.CommonGameData = new List<CommonGameData>
            {
                new CommonGameData
                {
                    Id = 1,
                    MainVisibleModuleId = _scenarioDataDto.VisibleModuleIdStart
                }
            };
            foreach (var intermissionModule in _scenarioDataDto.IntermissionModules)
            {
                ConvertAndSaveIntermissionModule(intermissionModule);
            }
            foreach (var emailModule in _scenarioDataDto.EmailModules)
            {
                ConvertAndSaveEmailModule(emailModule);
            }
            foreach (var browserModule in _scenarioDataDto.BrowserModules)
            {
                ConvertAndSaveBrowserModule(browserModule);
            }
            return _gameDbContext;
        }

        private IntermissionModule ConvertAndSaveIntermissionModule(IntermissionModuleDto intermissionModuleDto)
        {
            var resultIntermissionModule = new IntermissionModule
            {
                CurrentlyVisibleFrameId = intermissionModuleDto.CurrentIntermissionFrameId,
                ModuleId = intermissionModuleDto.ModuleId,
                IntermissionFrameComponents = intermissionModuleDto.IntermissionFrames?.Select(intermissionFrame =>
                    ConvertAndSaveIntermissionFrame(intermissionFrame, intermissionModuleDto.ModuleId)).ToList()
            };
            _gameDbContext.IntermissionModules.Add(resultIntermissionModule);
            _gameDbContext.Modules.Add(new Module
            {
                Id = resultIntermissionModule.ModuleId,
                IsVisible = true
            });
            return resultIntermissionModule;
        }

        private EmailModule ConvertAndSaveEmailModule(EmailModuleDto emailModuleDto)
        {
            var resultEmailModule = new EmailModule
            {
                NewEmailSubject = emailModuleDto.NewEmailSubject,
                ModuleId = emailModuleDto.ModuleId,
                SentEmails = emailModuleDto.SentEmails?.Select(sentEmail => ConvertAndSaveEmailComponent(sentEmail, true, emailModuleDto.ModuleId)).ToList(),
                RegularEmails = emailModuleDto.ReceivedEmails?.Select(receivedEmail => ConvertAndSaveEmailComponent(receivedEmail, false, emailModuleDto.ModuleId)).ToList(),
                Recipients = emailModuleDto.Recipients?.Select(recipient => ConvertAndSaveRecipientComponent(recipient))
            };
            _gameDbContext.EmailModules.Add(resultEmailModule);
            _gameDbContext.Modules.Add(new Module
            {
                Id = resultEmailModule.ModuleId,
                IsVisible = true
            });
            return resultEmailModule;
        }

        private BrowserModule ConvertAndSaveBrowserModule(BrowserModuleDto browserModuleDto)
        {
            var resultBrowserModule = new BrowserModule
            {
                SearchingMinigame = browserModuleDto.SearchingMinigames.Select(searchingMinigame =>
                    ConvertAndSaveSearchingMinigameComponent(searchingMinigame))
                    .FirstOrDefault(),
                SearchingMinigameComponentId = browserModuleDto.SearchingMinigames?.Select(searchingMinigame => searchingMinigame.ComponentId)
                    .FirstOrDefault() ?? default,
                ModuleId = browserModuleDto.ModuleId
            };
            _gameDbContext.BrowserModules.Add(resultBrowserModule);
            _gameDbContext.Modules.Add(new Module
            {
                Id = resultBrowserModule.ModuleId,
                IsVisible = true
            });
            return resultBrowserModule;
        }

        private IntermissionFrameComponent ConvertAndSaveIntermissionFrame(IntermissionFrameDto intermissionFrameDto, int parentModuleId)
        {
            var resultIntermissionFrame = new IntermissionFrameComponent
            {
                TextParagraph = intermissionFrameDto.Text,
                ButtonComponent = intermissionFrameDto.Buttons?.Select(button => ConvertAndSaveButtonComponentWithActions(button))
                    .FirstOrDefault(),
                ButtonComponentId = intermissionFrameDto.Buttons?.Select(button => (int?)button.ComponentId).FirstOrDefault(),
                ComponentId = intermissionFrameDto.ComponentId,
                FrameType = intermissionFrameDto.FrameType,
                IntermissionModuleId = parentModuleId,
                QuestionComponent = intermissionFrameDto.Questions?.Select(question => ConvertAndSaveQuestionComponent(question)).FirstOrDefault(),
                QuestionComponentId = intermissionFrameDto.Questions?.Select(question => (int?)question.ComponentId)
                         .FirstOrDefault()
            };

            _gameDbContext.IntermissionFrameComponents.Add(resultIntermissionFrame);
            _gameDbContext.Components.Add(new Component
            {
                Id = resultIntermissionFrame.ComponentId
            });
            return resultIntermissionFrame;
        }

        private QuestionComponent ConvertAndSaveQuestionComponent(QuestionDto questionDto)
        {
            if(questionDto == null)
            {
                return null;
            };
            Func<OptionDto, OptionComponent> convertAndSaveOptionComponent = option => 
            {
                var optionResult = new OptionComponent
                {
                    ComponentId = option.ComponentId,
                    QuestionComponentId = questionDto.ComponentId,
                    Text = option.Text
                };
                _gameDbContext.OptionComponents.Add(optionResult);
                _gameDbContext.Components.Add(new Component 
                {
                    Id = optionResult.ComponentId
                });
                return optionResult;
            };

            var resultQuestion = new QuestionComponent
            {
                ComponentId = questionDto.ComponentId,
                Text = questionDto.Text,
                OptionComponents = questionDto.Options?.Select(option => convertAndSaveOptionComponent(option))
                    .ToList()
            };

            _gameDbContext.QuestionComponents.Add(resultQuestion);
            _gameDbContext.Components.Add(new Component
            {
                Id = resultQuestion.ComponentId
            });
            return resultQuestion;
        }

        private EmailComponent ConvertAndSaveEmailComponent(EmailComponentDto emailDto, bool isSentEmail, int moduleId)
        {
            var resultEmail = new EmailComponent
            {
                Sender = emailDto.Sender,
                Subject = emailDto.Subject,
                IsSentEmail = isSentEmail,
                Active = emailDto.Active,
                ComponentId = emailDto.ComponentId,
                ContentFooter = emailDto.ContentFooter,
                ContentHeader = emailDto.ContentHeader,
                Date = emailDto.Date,
                Paragraphs = emailDto.EmailParagraphs?.Select(paragraph => new EmailComponentParagraph
                {
                    Id = emailComponentParagraphId++,
                    Content = paragraph,
                    EmailComponentId = emailDto.ComponentId
                }).ToList(),
                EmailModuleId = moduleId
            };

            _gameDbContext.EmailComponentParagraphs.AddRange(resultEmail.Paragraphs);
            _gameDbContext.EmailComponents.Add(resultEmail);
            _gameDbContext.Components.Add(new Component
            {
                Id = resultEmail.ComponentId
            });
            return resultEmail;
        }

        private RecipientComponent ConvertAndSaveRecipientComponent(RecipientComponentDto recipientDto)
        {
            var recipientResult = new RecipientComponent
            {
                Active = recipientDto.Active,
                Address = recipientDto.Address,
                ComponentId = recipientDto.ComponentId,
                ContentFooter = recipientDto.ContentFooter,
                ContentHeader = recipientDto.ContentHeader,
                Description = recipientDto.Description,
                ButtonComponent = recipientDto.Buttons?.Select(button => ConvertAndSaveButtonComponentWithActions(button)).FirstOrDefault(),
                ButtonComponentId = recipientDto.Buttons?.Select(button => button.ComponentId)
                        .FirstOrDefault() ?? default,
                FirstParagraphs = recipientDto.FirstParagraphs?.Select(firstParagraph => ConvertNewEmailParagraph(firstParagraph, null, recipientDto.ComponentId))
                    .ToList()
            };
            _gameDbContext.RecipientComponents.Add(recipientResult);
            _gameDbContext.Components.Add(new Component
            {
                Id = recipientResult.ComponentId
            });
            return recipientResult;
        }

        private NewEmailParagraphComponent ConvertNewEmailParagraph(NewEmailParagraphComponentDto webParagraph, int? parentParagraphId, int recipientParagraphId)
        {
            var resultEmailParagraph = new NewEmailParagraphComponent
            {
                ChildrenParagraphs = webParagraph?.ChildrenParagraphs?
                    .Select(childrenParagraph => ConvertNewEmailParagraph(childrenParagraph, webParagraph.ComponentId, recipientParagraphId))
                    .ToList(),
                ComponentId = webParagraph.ComponentId,
                ParentParagraphId = parentParagraphId,
                RecipientComponentId = recipientParagraphId,
                Text = webParagraph.Text
            };
            _gameDbContext.NewEmailParagraphComponents.Add(resultEmailParagraph);
            _gameDbContext.Components.Add(new Component
            {
                Id = resultEmailParagraph.ComponentId
            });
            return resultEmailParagraph;
        }

        private SearchingMinigameComponent ConvertAndSaveSearchingMinigameComponent(SearchingMinigameDto searchingMinigameDto)
        {
            Func<WordDto, WordComponent> convertAndSaveWordComponent = wordComponentDto =>
            {
                var resultWord = new WordComponent
                {
                    SearchingMinigameComponentId = searchingMinigameDto.ComponentId,
                    ComponentId = wordComponentDto.ComponentId,
                    Value = wordComponentDto.Value
                };
                _gameDbContext.WordComponents.Add(resultWord);
                _gameDbContext.Components.Add(new Component
                {
                    Id = resultWord.ComponentId
                });
                return resultWord;
            };

            var resultSearchingMinigame = new SearchingMinigameComponent
            {
                Solution = searchingMinigameDto.Solution,
                ComponentId = searchingMinigameDto.ComponentId,
                Height = searchingMinigameDto.Height,
                IsCompleted = false,
                Width = searchingMinigameDto.Width,
                Words = searchingMinigameDto.Words.Select(word => convertAndSaveWordComponent(word))
            };

            _gameDbContext.SearchingMinigameComponents.Add(resultSearchingMinigame);
            _gameDbContext.Components.Add(new Component
            {
                Id = resultSearchingMinigame.ComponentId
            });
            return resultSearchingMinigame;
        }

        private ButtonComponent ConvertAndSaveButtonComponentWithActions(ButtonDto buttonDto)
        {
            if(buttonDto == null)
            {
                return null;
            }
            var resultButton = new ButtonComponent
            {
                ComponentId = buttonDto.ComponentId,
                Text = buttonDto.ButtonText
            };
            _gameDbContext.ButtonComponents.Add(resultButton);
            _gameDbContext.Components.Add(new Component
            {
                Id = buttonDto.ComponentId
            });
            ConvertAndSaveSwitchIntermissionFrameActions(buttonDto);
            ConvertAndSaveUpdateMainVisibleModuleActions(buttonDto);
            ConvertAndSaveAddRecipientToNewEmailActions(buttonDto);
            ConvertAndSaveSendEmailToPlayerActions(buttonDto);
            return resultButton;
        }

        private IEnumerable<SwitchIntermissionFrameAction> ConvertAndSaveSwitchIntermissionFrameActions(ButtonDto buttonDto)
        {
            if(buttonDto == null || buttonDto.SwitchIntermissionFramesActions == null)
            {
                return null;
            }
            var resultActions = buttonDto.SwitchIntermissionFramesActions.Select(action => new SwitchIntermissionFrameAction
            {
                ActionId = action.ActionId,
                IntermissionModuleId = action.IntermissionModuleId,

                NewIntermissionFrameComponentId = action.NewIntermissionFrameId
            }).ToList();
            _gameDbContext.SwitchIntermissionFrameActions.AddRange(resultActions);

            SaveGameAdditionalData("SwitchIntermissionFrame", buttonDto.ComponentId, buttonDto.SwitchIntermissionFramesActions);
            return resultActions;
        }

        private IEnumerable<UpdateMainVIsibleModuleAction> ConvertAndSaveUpdateMainVisibleModuleActions(ButtonDto buttonDto)
        {
            if (buttonDto == null || buttonDto.UpdateMainVisibleModuleActions == null)
            {
                return null;
            }
            var resultActions = buttonDto.UpdateMainVisibleModuleActions.Select(action => new UpdateMainVIsibleModuleAction
            {
                ActionId = action.ActionId,
                NewMainVisibleModuleId = action.NewMainVisibleModuleId
            }).ToList();
            _gameDbContext.UpdateMainVisibleModuleActions.AddRange(resultActions);

            SaveGameAdditionalData("UpdateMainVisibleModuleId", buttonDto.ComponentId, buttonDto.UpdateMainVisibleModuleActions);

            return resultActions;
        }

        private IEnumerable<AddRecipientToNewEmailAction> ConvertAndSaveAddRecipientToNewEmailActions(ButtonDto buttonDto)
        {
            if (buttonDto == null || buttonDto.AddRecipientToNewEmailActions == null)
            {
                return null;
            }
            var resultActions = buttonDto.AddRecipientToNewEmailActions.Select(action => new AddRecipientToNewEmailAction
            {
                ActionId = action.ActionId,
                RecipientComponentId = action.RecipientComponentId
            }).ToList();
            _gameDbContext.AddRecipientToNewEmailActions.AddRange(resultActions);

            SaveGameAdditionalData("AddRecipientToNewEmail", buttonDto.ComponentId, buttonDto.AddRecipientToNewEmailActions);

            return resultActions;
        }

        private IEnumerable<SendEmailToPlayerAction> ConvertAndSaveSendEmailToPlayerActions(ButtonDto buttonDto)
        {
            if (buttonDto == null || buttonDto.SendEmailToPlayerActions == null)
            {
                return null;
            }
            var resultActions = buttonDto.SendEmailToPlayerActions.Select(action => new SendEmailToPlayerAction
            {
                ActionId = action.ActionId,
                EmailComponentId = action.EmailComponentId
            });
            _gameDbContext.SendEmailToPlayerActions.AddRange(resultActions);

            SaveGameAdditionalData("SendEmailToPlayer", buttonDto.ComponentId, buttonDto.SendEmailToPlayerActions);

            return resultActions;
        }

        private void SaveGameAdditionalData(string actionType, int buttonComponentId, IEnumerable<ActionBaseDto> actions)
        {
            _gameDbContext.GameActions.AddRange(actions.Select(action => new GameAction
            {
                Id = action.ActionId,
                TimeFromTrigger = action.TimeFromTriggerMiliseconds,
                Type = actionType
            }).ToList());

            foreach (var action in actions)
            {
                _gameDbContext.OnClickOptions.Add(new OnClickOption
                {
                    Id = currentOnClickOptionId,
                    ComponentId = buttonComponentId,
                    ResultActionId = action.ActionId,
                    UseClickedComponentConstraint = action.ClickedOtherComponents != null && action.ClickedOtherComponents.Any()
                });

                if(action.ClickedOtherComponents != null)
                {
                    _gameDbContext.Contexts.AddRange(
                        action.ClickedOtherComponents.Select(clickedComponent => new Context
                        {
                            Id = currentContextId++,
                            ClickedComponentId = clickedComponent,
                            OnClickOptionId = currentOnClickOptionId
                        }).ToList());
                }

                if(action.AlreadyRunActionId != null)
                {
                    _gameDbContext.Contexts.AddRange(
                        action.AlreadyRunActionId.Select(alreadyRunActionId => new Context
                        {
                            AlreadyRunActionId = alreadyRunActionId,
                            OnClickOptionId = currentOnClickOptionId
                        }).ToList());
                }

                currentOnClickOptionId++;
            }
        }
    }
}
