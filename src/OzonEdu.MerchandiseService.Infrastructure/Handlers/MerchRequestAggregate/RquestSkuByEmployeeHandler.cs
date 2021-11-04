using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateRequestSkuByEmployee;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchRequestAggregate
{
    public class RquestSkuByEmployeeHandler : IRequestHandler<CreateRequestSkuByEmployeeCommand, int>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public RquestSkuByEmployeeHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }
        
        public async Task<int> Handle(CreateRequestSkuByEmployeeCommand request, CancellationToken cancellationToken)
        {
            var stockInDb = await _merchRequestRepository.RequestSkuByEmployee(123, new Sku(123), cancellationToken);
            if (stockInDb is not null)
                throw new Exception($"Stock item with sku 123 already exist");

            var newStockItem = new {Id = 123};

            
            return newStockItem.Id;
        }
    }
}