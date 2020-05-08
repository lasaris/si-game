using Seng.Common.Entities.Actions.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetSendEmailToPlayerActionDataQuery : IQuery<SendEmailToPlayerAction>
    {
        public int GameActionId { get; set; }
    }
}
