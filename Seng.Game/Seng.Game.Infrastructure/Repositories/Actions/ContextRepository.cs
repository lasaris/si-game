using Seng.Game.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Actions
{
    public class ContextRepository : IRepository<Context>
    {
        public void InsertMany(IEnumerable<Context> dataToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
