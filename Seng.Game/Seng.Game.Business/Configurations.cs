using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business
{
    public class Configurations
    {
        public const string ConnectionString = "Data Source=" + @"./../../../../SengDb.db";
        public const string StaticConnectionString = "Data Source=" + @"./../../../../SengStaticDb.db";
        public const string DbPath = "./../../../../SengDb.db";
        public const string DbResultsPath = "./../../../../SengResultsDb.db";
        public const string StaticDbPath = "./../../../../SengStaticDb.db";
        public const string EmptyDbPath = "./../../../../SengEmptyDb.db";
        public const string ScenarioConfigPath = "./../../../../scenario.json";
    }
}
