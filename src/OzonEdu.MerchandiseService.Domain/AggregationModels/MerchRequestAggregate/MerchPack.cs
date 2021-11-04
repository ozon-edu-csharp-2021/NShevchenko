using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchPack : Entity
    {
        public MerchPack(MerchPackName merchPackName)
        {
            MerchPackName = merchPackName;
        }

        public MerchPackName MerchPackName { get; }
    }
}