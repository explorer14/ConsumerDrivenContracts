using System;

namespace ContractBroker
{
    public class Contract
    {
        public string Key { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string JsonValue { get; set; }
    }
}