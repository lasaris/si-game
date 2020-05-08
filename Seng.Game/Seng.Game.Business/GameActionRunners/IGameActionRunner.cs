using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Business.GameActionRunners
{
    interface IGameActionRunner
    {
        Task<bool> RunGameAction(int gameActionId);
    }
}
