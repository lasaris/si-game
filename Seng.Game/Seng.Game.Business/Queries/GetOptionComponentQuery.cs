using Seng.Common.Entities.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Business.Queries
{
    public class GetOptionComponentQuery : IQuery<IEnumerable<OptionComponent>>
    {
        public int QuestionComponentId { get; set; }
    }
}
