using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateRequestSkuByEmployee
{
    public class CreateRequestSkuByEmployeeCommand : IRequest
    {
        public long Sku { get; init; }

        public long EmployeeId { get; init; }
    }
}