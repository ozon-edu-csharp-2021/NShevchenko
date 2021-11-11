using System;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest : Entity
    {
        public MerchRequest(Employee employee,
            Sku sku,
            RequestDate requestDate,
            MerchPack merchPack,
            RequestStatus requestStatus)
        {
            Employee = employee;
            Sku = sku;
            RequestDate = requestDate;
            MerchPack = merchPack;
            RequestStatus = requestStatus;
            if (requestStatus == RequestStatus.Done)
            {
                DoneDate = new DoneDate(DateTime.Now);
            }
            else
            {
                DoneDate = new DoneDate(new DateTime(1900, 1, 1));
            }
        }

        public Employee Employee { get; }

        public Sku Sku { get; }

        public RequestDate RequestDate { get; }

        public MerchPack MerchPack { get; }

        public RequestStatus RequestStatus { get; private set; }

        public DoneDate DoneDate { get; private set; }

        /// <summary>
        /// Смена статуса у запроса на выдачу
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeStatus(RequestStatus status)
        {
            if (RequestStatus.Equals(RequestStatus.Done))
                throw new MerchRequestStatusException($"Request in done. Change status unavailable");

            if (status == RequestStatus.Done)
            {
                DoneDate = new DoneDate(DateTime.Now);
            }

            RequestStatus = status;
        }
    }
}