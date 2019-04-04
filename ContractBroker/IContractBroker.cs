using System;
using System.Threading.Tasks;

namespace ContractBroker
{
    public interface IContractBroker
    {
        Task<Contract> GetLatestConsumerContract(string consumerKey);

        Task PublishConsumerContract(string consumerKey, string contractJson);
    }
}