using Seng.Game.Business.Commands;
using Seng.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.CommandExecutors
{
    public class RunNextIntermissionFrameActionCommandHandler : ICommandHandler<RunNextIntermissionFrameActionCommand, GameInstance>
    {
        public Task<GameInstance> Handle(RunNextIntermissionFrameActionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
