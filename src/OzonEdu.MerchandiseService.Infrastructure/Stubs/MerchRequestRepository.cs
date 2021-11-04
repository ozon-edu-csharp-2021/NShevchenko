using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<MerchRequest> CreateAsync(MerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchRequest> UpdateAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SkuMerchItem>> GetIssuedMerchByEmployee(long employeeId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchRequest>> RequestMerchPackByEmployee(long employeeId, MerchPack merchPack, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchRequest> RequestSkuByEmployee(long employeeId, Sku sku, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}