using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class SkuProperty : ValueObject
    {
        public SkuProperty(Dictionary<string, string> value)
        {
            Value = value;
        }

        public Dictionary<string, string> Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}