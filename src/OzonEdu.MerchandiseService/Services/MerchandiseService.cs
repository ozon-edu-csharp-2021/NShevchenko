using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<List<Sku>> GetByEmployee(long emploeeId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TakeMerch(SkuSearchModel item, long emploeeId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}