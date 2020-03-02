using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.Repositories
{
    interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void InsertMany(IEnumerable<TEntity> dataToInsert);
    }
}
