using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContractBroker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractBroker contractBroker;

        public ContractsController(IContractBroker contractBroker)
        {
            this.contractBroker = contractBroker;
        }

        [HttpPost("consumer")]
        public async Task<IActionResult> PublishConsumerContract(
            [FromBody] Contract contract)
        {
            await contractBroker.PublishConsumerContract(
                contract.Key,
                contract.JsonValue);

            return Ok();
        }

        [HttpPost("producer")]
        public async Task<IActionResult> PublishProducerContract(
            [FromBody] Contract contract)
        {
            await contractBroker.PublishConsumerContract(
                contract.Key,
                contract.JsonValue);

            return Ok();
        }

        [HttpGet("runtest/consumer/{consumerKey}/producer/{producerKey}")]
        public async Task<IActionResult> GetTestResults(
            string consumerKey,
            string producerKey)
        {
            return await Task.FromResult(
                Ok("Test succeeded!"));
        }
    }
}