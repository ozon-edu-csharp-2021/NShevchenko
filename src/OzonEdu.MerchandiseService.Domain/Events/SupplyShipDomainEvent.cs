using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    /// Пришла поставка
    /// </summary>
    public class SupplyShipDomainEvent : INotification
    {
        public Sku StockItemSku { get; }

        public SupplyShipDomainEvent(Sku stockItemSku)
        {
            StockItemSku = stockItemSku;
        }
    }
}