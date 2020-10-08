﻿using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Actions.IntermissionModule;
using Seng.Common.Entities.Components;
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
    }
}
