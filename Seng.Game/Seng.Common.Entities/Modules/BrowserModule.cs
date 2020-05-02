using Seng.Common.Entities.Components.BrowserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class BrowserModule : BasicEntity
    {
        public int SearchingMinigameComponentId { get; set; }

        public SearchingMinigameComponent SearchingMinigame { get; set; }

        public int ModuleId { get; set; }

        public Module Module { get; set; }
    }
}
