using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateRequestMerchpackByEmployee;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchRequestAggregate
{
    public class RequestMerchpackByEmployeeHandler : IRequestHandler<CreateRequestMerchpackByEmployeeCommand, int>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public RequestMerchpackByEmployeeHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }

        public async Task<int> Handle(CreateRequestMerchpackByEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var stockInDb = await _merchRequestRepository.RequestMerchPackByEmployee(123,
                new MerchPack(new MerchPackName("WelcomePack")), cancellationToken);
            if (stockInDb is not null)
                throw new Exception($"Stock item with sku 123 already exist");

            var newStockItem = new {Id = 123};
            return newStockItem.Id;
        }
    }
}