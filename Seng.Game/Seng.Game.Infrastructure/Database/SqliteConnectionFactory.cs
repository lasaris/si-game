using Seng.Game.Business;
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
            return CreateOpenConnection(Configurations.ConnectionString);
        }

        public IDbConnection CreateOpenConnection(string connectionString)
        {
            IDbConnection connection = new SQLiteConnection(connectionString);
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
