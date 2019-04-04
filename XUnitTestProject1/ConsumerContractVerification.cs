using Azure.TableStorage.Helper;
using ContractBroker;
using Provider;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class ConsumerContractVerification
    {
        [Theory]
        [InlineData("Consumer-Post-Proposal")]
        public async Task VerifiesThatProviderContractMatchesPublishedConsumerContract(
            string consumerKey)
        {
            var contractBroker = new AzureTableContractBroker(
                new TableConfiguration(
                    "UseDevelopmentStorage=true", 
                    "contracts"));
            var contractConsumerExpects = await contractBroker
                .GetLatestConsumerContract(consumerKey);
            Assert.True(
                ContractMatcher.DoContractsMatch<Proposal>(
                    contractConsumerExpects.JsonValue),
                $"Because the provider's contract " +
                $"doesn't match consumer's expectation for consumer key {consumerKey}" +
                $"Consumer expects {contractConsumerExpects.JsonValue}");
        }
    }
}