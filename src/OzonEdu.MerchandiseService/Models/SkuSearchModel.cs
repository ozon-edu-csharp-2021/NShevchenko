using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Models
{
    public class SkuSearchModel
    {
        public MerchSearchItem MerchItem { get; set; }

        public Dictionary<string, string> SkuProperty { get; set; }
    }
}