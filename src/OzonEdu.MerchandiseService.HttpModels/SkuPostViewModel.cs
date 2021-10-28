using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class SkuPostViewModel
    {
        public MerchItemPostViewModel MerchItem { get; set; }

        public Dictionary<string, string> SkuProperty { get; set; }
    }
}