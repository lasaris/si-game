using Seng.Game.Business.Commands;
using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seng.Common.Entities.Modules;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    public class RunNextIntermissionFrameActionCommandHandler : ICommandHandler<RunNextIntermissionFrameActionCommand, IntermissionModule>
    {
        public Task<IntermissionModule> Handle(RunNextIntermissionFrameActionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
