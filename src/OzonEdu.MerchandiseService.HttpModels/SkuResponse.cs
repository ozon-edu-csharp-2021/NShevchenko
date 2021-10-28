using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class SkuResponse
    {
        public long SkuId { get; set; }

        public MerchItemResponse MerchItem { get; set; }

        public Dictionary<string, string> SkuProperty { get; set; }
    }
}