using System;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;
using Xunit;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Request_With_Request_Values()
        {
            //Arrange
            //Mocking what request is gonna look line
            var request = new RoomBookingRequest{
                FullName = "Test Name",
                Email = "test.request.com",
                Date = new DateTime(2021, 12, 13)
            };

            var processor = new RoomBookingRequestProcessor();

            //Act
            //The method BookRoom should return RoomBookingResult
            RoomBookingResult result = processor.BookRoom(request);

            //Assert
            Assert.NotNull(result);

            
            Assert.Equal(request.FullName, result.FullName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);

            result.ShouldNotBeNull();
            result.FullName.ShouldBe(request.FullName);
        }   
    }
}