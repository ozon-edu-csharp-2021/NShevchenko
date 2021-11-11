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
            var requestListInDb = await _merchRequestRepository.RequestMerchPackByEmployee(request.EmployeeId,
                new MerchPack(new MerchPackName(request.MerchPackName)), cancellationToken);
            if (requestListInDb is not null || requestListInDb.Count <= 0)
                throw new Exception($"Request denied");

            // TODO запросить по каждому запросу наличие Sku на складе
            // если есть оповестить сотрудника и пометить заявку выполненной
            //  await _merchRequestRepository.UpdateAsync(requestInDb, RequestStatus.Done);

            return requestListInDb.Count;
        }
    }
}