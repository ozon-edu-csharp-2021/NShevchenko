using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchRequestAggregate
{
    public class GetIssuedMerchByEmployeeQuery : IRequest<int>
    {
        public long EmployeeId { get; set; }
    }
}