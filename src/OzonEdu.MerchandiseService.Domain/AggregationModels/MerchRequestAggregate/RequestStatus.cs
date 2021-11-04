using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus Wait = new(1, "Wait");
        public static RequestStatus Done = new(1, "Done");
        
        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}