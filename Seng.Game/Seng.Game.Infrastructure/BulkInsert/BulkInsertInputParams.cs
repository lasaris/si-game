using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.BulkInsert
{
    class BulkInsertInputParams
    {
        public string TableName { get; set; }

        public IEnumerable<string> ParamsNames { get; set; }

        public IEnumerable<object> DataToInsert { get; set; }
    }
}
