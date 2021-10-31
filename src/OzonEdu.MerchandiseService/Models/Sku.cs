using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Models
{
    public class Sku
    {
        public Sku(long itemId, MerchItem merchItem, Dictionary<string, string> skuProperty)
        {
            SkuId = itemId;
            MerchItem = merchItem;
            SkuProperty = skuProperty;
        }

        public long SkuId { get; }

        public MerchItem MerchItem { get; }

        public Dictionary<string, string> SkuProperty { get; }
    }
}