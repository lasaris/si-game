using Seng.Common.Entities.Actions.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetAddRecipientToNewEmailActionQuery : IQuery<AddRecipientToNewEmailAction>
    {
        public int GameActionId { get; set; }
    }
}
