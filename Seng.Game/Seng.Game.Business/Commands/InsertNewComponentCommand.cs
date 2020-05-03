using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class InsertNewComponentCommand : ICommand<bool>
    {
        public int ComponentId { get; set; }
    }
}
