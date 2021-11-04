using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class EmployeeNotificationDomainEvent: INotification
    {
        public Sku StockItemSku { get; }
        public Employee Employee { get; }

        public EmployeeNotificationDomainEvent(Sku stockItemSku, Employee employee)
        {
            StockItemSku = stockItemSku;
            Employee = employee;
        }
    }
    
}