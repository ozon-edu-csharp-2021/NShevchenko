using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchRequestTests
    {
        [Fact]
        public void ChangeStatusTest()
        {
            //Arrange 
            var merchRequest = new MerchRequest(
                new Employee(123),
                new Sku(1234),
                new RequestDate(DateTime.Now),
                merchPack: null,
                RequestStatus.Wait);


            //Act
            merchRequest.ChangeStatus(RequestStatus.Done);

            //Assert
            Assert.Equal(RequestStatus.Done, merchRequest.RequestStatus);
        }
    }
}