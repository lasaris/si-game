using Seng.Common.Entities.Components.IntermissionModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetQuestionComponentQuery : IQuery<QuestionComponent>
    {
        public int QuestionComponentId { get; set; }
    }
}
