using Seng.Game.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class GameActionRepository : IRepository<GameAction>
    {
        public void InsertMany(IEnumerable<GameAction> dataToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
