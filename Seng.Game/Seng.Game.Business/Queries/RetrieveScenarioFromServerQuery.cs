using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class RetrieveScenarioFromServerQuery : IQuery<GameDbContext>
    {
        public string GameToken { get; set; }
    }
}
