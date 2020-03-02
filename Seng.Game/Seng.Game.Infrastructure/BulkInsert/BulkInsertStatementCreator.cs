using Dapper;
using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Game.Infrastructure.BulkInsert
{
    class BulkInsertStatementCreator<TEntity> : IBulkInsertStatementCreator<TEntity> 
        where TEntity : IEntity
    {

        public string Insert(BulkInsertInputParams insertParameters)
        {
            string sql = $"Insert into {insertParameters.TableName} (";

            sql += string.Join(",", insertParameters.ParamsNames);
            sql += ") Values (";
            sql += string.Join(",", insertParameters.ParamsNames.Select(parameter => "@" + parameter));
            sql += ")";

            return sql;
        }
    }
}
