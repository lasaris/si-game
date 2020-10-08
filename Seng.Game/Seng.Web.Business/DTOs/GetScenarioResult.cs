using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Seng.Web.Business.DTOs
{
    public class GetScenarioResult
    {
        public ScenarioDataDto FormData { get; set; }
        public JsonElement Schema { get; set; }
        public CurrentIdData CurrentIdData { get; set; }
    }
}
