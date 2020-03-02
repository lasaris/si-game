using Seng.Game.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Common.Entities.Components
{
    public class ButtonRepository : IRepository<Button>
    {
        public void InsertMany(IEnumerable<Button> dataToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
