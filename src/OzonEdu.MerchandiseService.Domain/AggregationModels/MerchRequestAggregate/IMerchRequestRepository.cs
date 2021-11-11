using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления <see cref="MerchRequest"/>
    /// </summary>
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        /// <summary>
        /// Найти все выданные позиции по сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Товарные позиции, выданные сотруднику</returns>
        Task<List<SkuMerchItem>> GetIssuedMerchByEmployee(long employeeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Запрос выдачи сотруднику MerchPack
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="merchPack">MerchPack для выдачи</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Список добавленных запросов Sku для для дальнейшей обработки</returns>
        Task<List<MerchRequest>> RequestMerchPackByEmployee(long employeeId, MerchPack merchPack,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Запрос выдачи сотруднику Sku
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="sku">Sku для выдачи</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Добавленный запрос Sku</returns>
        Task<MerchRequest> RequestSkuByEmployee(long employeeId, Sku sku,
            CancellationToken cancellationToken = default);
    }
}