using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class CommandBasicResult
    {
        public bool IsCommandSuccessful { get; set; } 

        public string ErrorMessage { get; set; }
    }
}
