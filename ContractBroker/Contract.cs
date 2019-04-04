using System;

namespace ContractBroker
{
    public class Contract
    {
        public DateTimeOffset Timestamp { get; set; }

        public string JsonValue { get; set; }
    }
}