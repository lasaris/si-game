using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions.EmailModule
{
    public class AddRecipientToNewEmailAction
    {
        public int ActionId { get; set; }

        public int RecipientComponentId { get; set; }
    }
}
