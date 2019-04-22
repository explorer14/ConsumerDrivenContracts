using System;
using System.Threading.Tasks;

namespace ContractBroker
{
    public interface IContractBroker
    {
        Task<Contract> GetLatestConsumerContract(string consumerKey);

        Task<Contract> GetLatestProducerContract(string producerKey);

        Task PublishConsumerContract(string consumerKey, string contractJson);

        Task PublishProducerContract(string producerKey, string contractJson);
    }
}