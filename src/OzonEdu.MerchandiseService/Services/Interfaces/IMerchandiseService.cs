using OzonEdu.MerchandiseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<bool> TakeMerch(SkuSearchModel item, long emploeeId, CancellationToken token);

        Task<List<Sku>> GetByEmployee(long emploeeId, CancellationToken token);
    }
}