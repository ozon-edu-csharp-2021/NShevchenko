using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchItem : Entity
    {
        public MerchItem(ItemName itemName, ItemType type, ItemProperty itemProperty)
        {
            ItemName = itemName;
            Type = type;
            ItemProperty = itemProperty;
        }

        public ItemType Type { get; }
        
        public ItemName ItemName { get; }

        public ItemProperty ItemProperty { get; }
    }
}