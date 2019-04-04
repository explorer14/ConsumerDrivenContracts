using Azure.TableStorage.Helper;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractBroker
{
    public class AzureTableContractBroker : IContractBroker
    {
        private readonly TableConfiguration config;

        public AzureTableContractBroker(TableConfiguration config)
        {
            this.config = config;
        }

        public async Task<Contract> GetLatestConsumerContract(string consumerKey)
        {
            var tableHelper = new AzureTableHelper<ContractEntity>(config);

            var contracts = (await tableHelper
                .ReadByPartitionKey(consumerKey))
                .ToList()
                .OrderByDescending(x=>x.Timestamp);

            return new Contract
            {
                Timestamp = contracts.First().Timestamp,
                JsonValue = contracts.First().JsonContract
            };
        }

        public async Task PublishConsumerContract(
            string consumerKey, string contractJson)
        {
            var tableHelper = new AzureTableHelper<ContractEntity>(config);
            await tableHelper.Insert(
                new ContractEntity
                {
                    JsonContract = contractJson,
                    PartitionKey = consumerKey,
                    RowKey = Guid.NewGuid().ToString()
                });
        }
    }

    public class ContractEntity : TableEntity
    {
        public string JsonContract { get; set; }
    }
}
