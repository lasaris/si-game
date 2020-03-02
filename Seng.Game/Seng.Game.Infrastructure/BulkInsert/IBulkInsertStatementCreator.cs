using Seng.Common.Entities;
using System.Data;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.BulkInsert
{
    interface IBulkInsertStatementCreator<TEntity> 
        where TEntity : IEntity
    {
        string Insert(BulkInsertInputParams insertParameters);
    }
}