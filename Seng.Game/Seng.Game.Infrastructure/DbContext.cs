using Seng.Common.Entities.Actions;
using Seng.Common.Entities.Actions.IntermissionModule;
using Seng.Common.Entities.Components;
using Seng.Common.Entities.Components.IntermissionModule;
using Seng.Common.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure
{
    class DbContext
    {
        public List<SwitchIntermissionFrameAction> SwitchIntermissionFrameActions { get; set; }
        public List<Context> Contexts { get; set; }
        public List<GameAction> GameActions { get; set; }
        public List<OnClickOption> OnClickOptions { get; set; }
        public List<IntermissionFrame> IntermissionFrames { get; set; }
        public List<IntermissionText> IntermissionTexts { get; set; }
        public List<Button> Buttons { get; set; }
        public List<Component> Components { get; set; }
        public List<IntermissionModule> IntermissionModules { get; set; }
        public List<Module> Modules { get; set; }
    }
}
