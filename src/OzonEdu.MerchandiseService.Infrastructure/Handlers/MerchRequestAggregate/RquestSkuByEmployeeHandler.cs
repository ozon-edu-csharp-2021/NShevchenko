using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateRequestSkuByEmployee;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchRequestAggregate
{
    public class RquestSkuByEmployeeHandler : IRequestHandler<CreateRequestSkuByEmployeeCommand>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public RquestSkuByEmployeeHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }

        public async Task<Unit> Handle(CreateRequestSkuByEmployeeCommand request, CancellationToken cancellationToken)
        {
            var requestInDb =
                await _merchRequestRepository.RequestSkuByEmployee(request.EmployeeId, new Sku(request.Sku),
                    cancellationToken);
            if (requestInDb is null)
                throw new Exception($"Request denied");
            var issuedMerchList = await _merchRequestRepository.GetIssuedMerchByEmployee(request.EmployeeId);
            // TODO проверить что сотруднику можно выдать мерч
            // запросить по запросу наличие Sku на складе
            // если есть оповестить сотрудника и пометить заявку выполненной
            //  await _merchRequestRepository.UpdateAsync(requestInDb, RequestStatus.Done);

            return Unit.Value;
        }
    }
}