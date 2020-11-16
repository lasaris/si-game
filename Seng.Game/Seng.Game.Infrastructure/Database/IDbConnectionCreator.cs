﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Seng.Game.Infrastructure.Database
{
    interface IDbConnectionCreator
    {
        IDbConnection CreateOpenConnection();

        IDbConnection CreateOpenConnection(string connectionString);

        long GetLastInsertedRowId(IDbConnection dbConnection);
    }
}
