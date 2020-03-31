using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.BulkInsert
{
    interface IBulkInsertExecutor
    {
        Task ExecuteAsync(string bulkInsertSql, IEnumerable<object> dataToInsert, IDbConnection connection);
    }
}