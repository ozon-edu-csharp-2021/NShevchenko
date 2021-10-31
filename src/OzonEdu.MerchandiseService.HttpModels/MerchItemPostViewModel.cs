using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchItemPostViewModel
    {
        public string ItemName { get; set; }

        public Dictionary<string, string> ItemProperty { get; set; }
    }
}