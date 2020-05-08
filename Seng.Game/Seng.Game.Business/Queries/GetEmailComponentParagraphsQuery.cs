using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetEmailComponentParagraphsQuery : IQuery<IEnumerable<EmailComponentParagraph>>
    {
        public int EmailComponentId { get; set; }
    }
}
