using Seng.Game.Business.GameActionRunners;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.GameActionRunners
{
    interface IGameActionFactory
    {
        void Register(GameActionType gameActionType, Type typeOfGameAction);

        IGameActionRunner GetGameActionRunner(GameActionType gameActionType);
    }
}
