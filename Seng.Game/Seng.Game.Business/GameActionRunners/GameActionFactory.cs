using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.GameActionRunners
{
    class GameActionFactory : IGameActionFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private IDictionary<GameActionType, Type> _typeDictionary;

        public GameActionFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _typeDictionary = new Dictionary<GameActionType, Type>();
        }

        public IGameActionRunner GetGameActionRunner(GameActionType gameActionType)
        {
            bool isTypeFound = _typeDictionary.TryGetValue(gameActionType, out var typeOfGameAction);
            return isTypeFound ? (IGameActionRunner)_serviceProvider.GetService(typeOfGameAction) : null;
        }

        public void Register(GameActionType gameActionType, Type typeOfGameAction)
        {
            if(typeOfGameAction != null)
            {
                _typeDictionary.TryAdd(gameActionType, typeOfGameAction);
            }
        }
    }
}
