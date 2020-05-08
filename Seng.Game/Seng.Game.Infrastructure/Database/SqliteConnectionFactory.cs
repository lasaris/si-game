using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Seng.Game.Infrastructure.Database
{
    class SqliteConnectionFactory : IDbConnectionCreator
    {
        public IDbConnection CreateOpenConnection()
        {
            IDbConnection connection = new SQLiteConnection("Data Source=" + "../../../../SengLocalDb.db");
            connection.Open();
            return connection;
        }

        public long GetLastInsertedRowId(IDbConnection dbConnection)
        {
            var sqliteConnection = (SQLiteConnection)dbConnection;
            return sqliteConnection.LastInsertRowId;
        }
    }
}
