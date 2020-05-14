using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands.ActionCommands
{
    public class MakeRecipientActiveCommand : ICommand<bool>
    {
        public int RecipientId { get; set; }
    }
}
