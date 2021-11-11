using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;


namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchRequestAggregate
{
    public class GetIssuedMerchByEmployeeQuery : IRequest<List<MerchRequest>>
    {
        public long EmployeeId { get; set; }
    }
}