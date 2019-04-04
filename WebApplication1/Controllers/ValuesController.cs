using ContractBroker;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Threading.Tasks;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IContractBroker contractBroker;

        public ValuesController(IContractBroker contractBroker)
        {
            this.contractBroker = contractBroker;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Proposal value)
        {
            Log.Logger.Information("Recieved {@proposal}", value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContract()
        {
            await contractBroker.PublishConsumerContract(
                "Consumer-Post-Proposal",
                JsonConvert.SerializeObject(new Proposal()));

            return Ok();
        }
    }
}