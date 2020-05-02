using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components.BrowserModule
{
    public class WordComponent : BasicEntity
    {
        public string Value { get; set; }

        public int SearchingMinigameComponentId { get; set; }

        public int ComponentId { get; set; }
    }
}
