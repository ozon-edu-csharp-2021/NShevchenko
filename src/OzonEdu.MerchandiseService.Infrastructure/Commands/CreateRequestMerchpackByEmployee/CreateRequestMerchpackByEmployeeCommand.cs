using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateRequestMerchpackByEmployee
{
    public class CreateRequestMerchpackByEmployeeCommand : IRequest<int>
    {
        public long EmployeeId;
        public string MerchPackName;
    }
}