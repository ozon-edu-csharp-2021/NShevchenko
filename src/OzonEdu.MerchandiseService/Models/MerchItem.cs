using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long itemId, string itemName, Dictionary<string, string> itemProperty)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemProperty = itemProperty;
        }

        public long ItemId { get; }

        public string ItemName { get; }

        public Dictionary<string, string> ItemProperty { get; }
    }
}