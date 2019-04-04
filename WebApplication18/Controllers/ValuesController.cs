using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Proposal value)
        {
            Log.Logger.Information("Publishing {@proposal}", value);

            using(var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:6000");

                var content = new StringContent(
                    JsonConvert.SerializeObject(value), 
                    Encoding.UTF8, 
                    "application/json");
                await client.PostAsync("api/values", content);

                return Ok();
            }
        }
    }
}