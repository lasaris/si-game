using Seng.Common.Entities.Components.BrowserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetWordsQuery : IQuery<IEnumerable<WordComponent>>
    {
        public int SearchingMinigameComponentId { get; set; }
    }
}
