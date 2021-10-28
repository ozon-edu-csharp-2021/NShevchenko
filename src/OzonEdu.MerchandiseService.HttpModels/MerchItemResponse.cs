using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchItemResponse
    {
        public long ItemId { get; set; }

        public string ItemName { get; set; }

        public Dictionary<string, string> ItemProperty { get; set; }
    }
}