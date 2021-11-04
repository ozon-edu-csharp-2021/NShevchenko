using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchPackItem : Entity
    {
        public MerchPackItem(MerchPack merchPack, MerchItem merchItem)
        {
            MerchPack = merchPack;
            MerchItem = merchItem;
        }

        public MerchPack MerchPack { get; }

        public MerchItem MerchItem { get; }
    }
}