using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class RetrieveScenarioFromServerQuery : IQuery<bool>
    {
        public string GameToken { get; set; }
    }
}
