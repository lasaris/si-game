using Seng.Game.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components
{
    public class ComponentRepository : IRepository<Component>
    {
        public void InsertMany(IEnumerable<Component> dataToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
