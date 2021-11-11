using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class DoneDate : ValueObject
    {
        public DateTime Value { get; }

        public DoneDate(DateTime requestDate)
        {
            Value = requestDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}