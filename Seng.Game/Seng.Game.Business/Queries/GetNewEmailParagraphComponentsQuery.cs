using Seng.Common.Entities.Components.EmailModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetNewEmailParagraphComponentsQuery : IQuery<IEnumerable<NewEmailParagraphComponent>>
    {
        public int RecipientComponentId { get; set; }
    }
}
