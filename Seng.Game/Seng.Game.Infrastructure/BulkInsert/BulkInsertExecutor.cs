using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.BulkInsert
{
    class BulkInsertExecutor : IBulkInsertExecutor
    {

        public async Task ExecuteAsync(string bulkInsertSql, IEnumerable<object> dataToInsert, IDbConnection connection)
        {
            foreach (var rowToInsert in dataToInsert)
            {
                await connection.ExecuteAsync(bulkInsertSql, rowToInsert);
            }
        }
    }
}
