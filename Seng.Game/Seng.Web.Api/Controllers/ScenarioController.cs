using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Seng.Web.Business.DTOs;

namespace Seng.Web.Api.Controllers
{
    [ApiController]
    [Route("scenario")]
    public class ScenarioController : ControllerBase
    {
        private readonly ILogger<ScenarioController> _logger;
        private IMapper _mapper;

        public ScenarioController(ILogger<ScenarioController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        [EnableCors("SiteCorsPolicy")]
        public async Task<ActionResult> AddScenario([FromQuery]string password, [FromQuery]string gameId,
            [FromBody] GetScenarioRequest scenarioData)
        {
            if (string.IsNullOrEmpty(gameId))
            {
                gameId = DateTime.Now.Ticks.ToString();
            }

            //hash password
            System.IO.File.WriteAllText($"{gameId}_meta.txt", password);

            using (Stream fs = new FileStream($"{gameId}.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, scenarioData.FormData);
            }

            using (Stream fs = new FileStream($"{gameId}_schema.json", FileMode.OpenOrCreate))
            {
                var jObject = scenarioData.Schema;//JObject.Parse(scenarioData.Schema);
                await JsonSerializer.SerializeAsync(fs, jObject);
            }
            using (Stream fs = new FileStream($"{gameId}_currentIdData.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, scenarioData.CurrentIdData);
            }
            return Ok(gameId);
        }

        [HttpGet]
        [Route("get")]
        [EnableCors("SiteCorsPolicy")]
        public async Task<ActionResult> GetScenario([FromQuery]string gameId, [FromQuery]string password)
        {
            if(!ValidatePassword(gameId, password))
            {
                return Forbid();
            }

            var result = new GetScenarioResult();
            using (Stream r = new FileStream($"{gameId}.json", FileMode.Open))
            {
                result.FormData = await JsonSerializer.DeserializeAsync<ScenarioDataDto>(r, new JsonSerializerOptions {IgnoreNullValues = true});
            }

            using (Stream r = new FileStream($"{gameId}_schema.json", FileMode.Open))
            {
                result.Schema = await JsonSerializer.DeserializeAsync<JsonElement>(r, new JsonSerializerOptions { IgnoreNullValues = true });
            }

            using (Stream r = new FileStream($"{gameId}_currentIdData.json", FileMode.Open))
            {
                result.CurrentIdData = await JsonSerializer.DeserializeAsync<CurrentIdData>(r, new JsonSerializerOptions { IgnoreNullValues = true });
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("game/get")]
        [EnableCors("SiteCorsPolicy")]
        public async Task<ActionResult> GetScenarioForGame([FromQuery]string gameId)
        {
            using (Stream r = new FileStream($"{gameId}.json", FileMode.Open))
            {
                var result = await JsonSerializer.DeserializeAsync<ScenarioDataDto>(r, new JsonSerializerOptions { IgnoreNullValues = true });
                return Ok(result);
            }
        }

        private bool ValidatePassword(string gameId, string password)
        {
            //hash password
            if (System.IO.File.Exists($"{gameId}_meta.txt"))
            {
                string realPasswordHash = System.IO.File.ReadAllText($"{gameId}_meta.txt");
                if(password == realPasswordHash)
                {
                    return true;
                }
            }
            else if (!System.IO.File.Exists($"{gameId}.json"))
            {
                return true;
            }
            return false;
        }
    }
}
