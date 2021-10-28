using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchSearchItem
    {
        public string ItemName { get; set; }

        public Dictionary<string, string> ItemProperty { get; set; }
    }
}