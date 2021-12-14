using System;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;
using Xunit;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;
        private readonly RoomBookingRequest _request;

        public RoomBookingRequestProcessorTest()
        {
            //Arrange
            _processor = new RoomBookingRequestProcessor();


            _request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test.request.com",
                Date = new DateTime(2021, 12, 13)
            };
        }

        [Fact]
        public void Should_Return_Room_Booking_Request_With_Request_Values()
        {
            //Arrange -> Constructor
            //Mocking what request is gonna look line


            //Act
            //The method BookRoom should return RoomBookingResult
            RoomBookingResult result = _processor.BookRoom(_request);

            //Assert
            Assert.NotNull(result);

            
            Assert.Equal(request.FullName, result.FullName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);

            result.ShouldNotBeNull();
            result.FullName.ShouldBe(request.FullName);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookRoom(null));

            Assert.Equal("bookingRequest", exception.ParamName);
            
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            _processor.BookRoom(_request);
        }
    }
}