using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchRequestAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchRequestTests
    {
        [Fact]
        public void ChangeStatusSuccessTest()
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

        [Fact]
        public void ChangeStatusIfDoneTest()
        {
            //Arrange 
            var merchRequest = new MerchRequest(
                new Employee(123),
                new Sku(1234),
                new RequestDate(DateTime.Now),
                merchPack: null,
                RequestStatus.Done);

            //Act

            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.ChangeStatus(RequestStatus.Done));
        }

        [Fact]
        public void CreateDateTest()
        {
            //Arrange 
            var dateRequest = DateTime.Now;

            //Act
            var merchRequest = new MerchRequest(
                new Employee(123),
                new Sku(1234),
                new RequestDate(dateRequest),
                merchPack: null,
                RequestStatus.Wait);

            //Assert
            Assert.Equal(dateRequest, merchRequest.RequestDate.Value);
            Assert.Equal(new DateTime(1900, 1, 1), merchRequest.DoneDate.Value);
        }

        [Fact]
        public void ChangeStatusDateTest()
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
            Assert.NotEqual(new DateTime(1900, 1, 1), merchRequest.DoneDate.Value);
        }

        [Fact]
        public void CreateStatusDoneDateTest()
        {
            //Arrange 
            //Act
            var merchRequest = new MerchRequest(
                new Employee(123),
                new Sku(1234),
                new RequestDate(DateTime.Now),
                merchPack: null,
                RequestStatus.Done);

            //Assert
            Assert.NotEqual(new DateTime(1900, 1, 1), merchRequest.DoneDate.Value);
        }
    }
}