using Seng.Game.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Modules
{
    public class ModuleRepository : IRepository<Module>
    {
        public void InsertMany(IEnumerable<Module> dataToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
