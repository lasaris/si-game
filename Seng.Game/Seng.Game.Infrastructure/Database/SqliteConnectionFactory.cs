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
            return new SQLiteConnection("Data Source=" + "../../../../SengLocalDb.db");
        }
    }
}
