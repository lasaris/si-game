using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.DTOs
{
    public class RetrieveScenarioResultDto
    {
        public bool IsRetrievedFromServer { get; set; }

        public bool IsSavedIntoDatabase { get; set; }
    }
}
