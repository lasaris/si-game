using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class InsertNewComponentCommand : ICommand<int>
    {
        public int? ComponentId { get; set; }
    }
}
