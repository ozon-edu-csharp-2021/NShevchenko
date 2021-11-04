
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class SkuMerchItem : Entity
    {
        public SkuMerchItem(Sku skuId, MerchItem merchItem, SkuProperty skuProperty)
        {
            SkuId = skuId;
            MerchItem = merchItem;
            SkuProperty = skuProperty;
        }

        public Sku SkuId { get; }

        public MerchItem MerchItem { get; }

        public SkuProperty SkuProperty { get; }
    }
}