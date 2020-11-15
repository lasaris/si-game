using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class InsertLogCommand : ICommand<bool>
    {
        public int ComponentId { get; set; }
        public IEnumerable<int> ClickedComponents { get; set; }
    }
}
