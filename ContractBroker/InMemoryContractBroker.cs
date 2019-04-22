using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractBroker
{
    public class InMemoryContractBroker : IContractBroker
    {
        private Dictionary<string, Contract> consumerContracts = 
            new Dictionary<string, Contract>()
        {
            {
                "consumer-api-1",
                new Contract
                {
                    JsonValue = "{'Quantity':0,'CurrentStockLevel':0}",
                    Timestamp = DateTimeOffset.UtcNow
                }
            },
            {
                "consumer-api-2",
                new Contract
                {
                    JsonValue = "{'Quantity':0,'IsActive':true}",
                    Timestamp = DateTimeOffset.UtcNow
                }
            }
        };

        public Task<Contract> GetLatestConsumerContract(string consumerKey)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contract> GetLatestProducerContract(string producerKey)
        {
            throw new NotImplementedException();
        }

        public Task PublishConsumerContract(string consumerKey, string contractJson)
        {
            consumerContracts.Add(consumerKey,
                new Contract
                {
                    JsonValue = contractJson,
                    Timestamp = DateTimeOffset.UtcNow
                });

            return Task.CompletedTask;
        }

        public Task PublishProducerContract(string producerKey, string contractJson)
        {
            throw new NotImplementedException();
        }
    }
}