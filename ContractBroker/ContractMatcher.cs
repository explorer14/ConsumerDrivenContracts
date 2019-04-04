using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ContractBroker
{
    public class ContractMatcher
    {
        public static bool DoContractsMatch<TProvider>(string contractJson)
        {
            JObject o = JObject.Parse(contractJson);
            var enumerator = o.GetEnumerator();
            var listOfFieldsConsumerExpects = new List<string>();

            while (enumerator.MoveNext())
            {
                listOfFieldsConsumerExpects.Add(
                    enumerator.Current.Key);
            }

            return DoContractsMatch<TProvider>(
                listOfFieldsConsumerExpects);
        }

        private static bool DoContractsMatch<TProvider>(
            IReadOnlyCollection<string> listOfFieldsConsumerExpects)
        {
            return typeof(TProvider)
                .GetProperties()
                .Select(x => x.Name)
                .Intersect(listOfFieldsConsumerExpects)
                .Count() == listOfFieldsConsumerExpects.Count;
        }
    }
}