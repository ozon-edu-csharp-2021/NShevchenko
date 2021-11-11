using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.Events;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class EmployeeNotificationDomainEventHandler : INotificationHandler<EmployeeNotificationDomainEvent>
    {
        public Task Handle(EmployeeNotificationDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}