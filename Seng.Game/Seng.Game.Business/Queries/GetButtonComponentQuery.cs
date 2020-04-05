using Seng.Common.Entities.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public class GetButtonComponentQuery : IQuery<ButtonComponent>
    {
        public int ButtonComponentId { get; set; }
    }
}
