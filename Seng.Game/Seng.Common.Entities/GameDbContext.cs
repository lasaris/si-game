using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Actions.EmailModule;
using Seng.Common.Entities.Actions.IntermissionModule;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.BrowserModule;
using Seng.Common.Entities.Components.EmailModule;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities
{
    public class GameDbContext
    {
        public List<SwitchIntermissionFrameAction> SwitchIntermissionFrameActions { get; set; }
        public List<Context> Contexts { get; set; }
        public List<GameAction> GameActions { get; set; }
        public List<OnClickOption> OnClickOptions { get; set; }
        public List<IntermissionFrameComponent> IntermissionFrameComponents { get; set; }
        public List<ButtonComponent> ButtonComponents { get; set; }
        public List<Component> Components { get; set; }
        public List<IntermissionModule> IntermissionModules { get; set; }
        public List<Module> Modules { get; set; }
        public List<QuestionComponent> QuestionComponents { get; set; }
        public List<OptionComponent> OptionComponents { get; set; }
        public List<CommonGameData> CommonGameData { get; set; }
        public List<EmailModule> EmailModules { get; set; }
        public List<BrowserModule> BrowserModules { get; set; }
        public List<SearchingMinigameComponent> SearchingMinigameComponents { get; set; }
        public List<WordComponent> WordComponents { get; set; }
        public List<EmailComponent> EmailComponents { get; set; }
        public List<EmailComponentParagraph> EmailComponentParagraphs { get; set; }
        public List<NewEmailParagraphComponent> NewEmailParagraphComponents { get; set; }
        public List<RecipientComponent> RecipientComponents { get; set; }
        public List<UpdateMainVIsibleModuleAction> UpdateMainVisibleModuleActions { get; set; }
        public List<AddRecipientToNewEmailAction> AddRecipientToNewEmailActions { get; set; }
        public List<SendEmailToPlayerAction> SendEmailToPlayerActions { get; set; }
    }
}
