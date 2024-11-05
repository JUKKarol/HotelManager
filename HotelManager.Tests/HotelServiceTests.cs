using System.Collections.Generic;
using HotelManager.Entities;
using HotelManager.Services.HotelService;
using Moq;
using Xunit;

namespace HotelManager.Tests
{
    public class HotelServiceTests
    {
        private readonly IHotelService _hotelService;
        private readonly Mock<IHotelService> _hotelServiceMock;

        public HotelServiceTests()
        {
            _hotelServiceMock = new Mock<IHotelService>();
            _hotelService = _hotelServiceMock.Object;
        }

        [Fact]
        public void GetAvailableRooms_WhenNoRoomsAvailable_ReturnsZero()
        {
            var hotel = new Hotel
            {
                Id = "H1",
                Name = "Hotel California",
                Rooms = new List<Room>
                {
                    new Room { RoomType = "DBL", RoomId = "201" },
                    new Room { RoomType = "DBL", RoomId = "202" }
                }
            };

            var bookings = new List<Booking>
            {
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 1),
                    Departure = new DateOnly(2024, 9, 3),
                    RoomType = "DBL",
                    RoomRate = "Prepaid"
                },
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 2),
                    Departure = new DateOnly(2024, 9, 5),
                    RoomType = "DBL",
                    RoomRate = "Standard"
                }
            };

            string hotelId = "H1";
            string roomType = "DBL";
            var arrival = new DateOnly(2024, 9, 3);
            var departure = new DateOnly(2024, 9, 4);

            _hotelServiceMock.Setup(hs => hs.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure))
                             .Returns(0);

            int availableRoomsCount = _hotelService.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure);

            Assert.Equal(0, availableRoomsCount);
        }

        [Fact]
        public void GetAvailableRooms_WhenOneRoomIsAvailable_ReturnsOne()
        {
            var hotel = new Hotel
            {
                Id = "H1",
                Name = "Hotel California",
                Rooms = new List<Room>
                {
                    new Room { RoomType = "SGL", RoomId = "101" },
                    new Room { RoomType = "SGL", RoomId = "102" },
                    new Room { RoomType = "DBL", RoomId = "201" },
                    new Room { RoomType = "DBL", RoomId = "202" }
                }
            };

            var bookings = new List<Booking>
            {
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 1),
                    Departure = new DateOnly(2024, 9, 3),
                    RoomType = "DBL",
                    RoomRate = "Prepaid"
                },
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 2),
                    Departure = new DateOnly(2024, 9, 5),
                    RoomType = "SGL",
                    RoomRate = "Standard"
                }
            };

            string hotelId = "H1";
            string roomType = "DBL";
            var arrival = new DateOnly(2024, 9, 3);
            var departure = new DateOnly(2024, 9, 4);

            _hotelServiceMock.Setup(hs => hs.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure))
                             .Returns(1);

            int availableRoomsCount = _hotelService.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure);

            Assert.Equal(1, availableRoomsCount);
        }

        [Fact]
        public void GetAvailableRooms_WhenTwoRoomsAvailable_ReturnsTwo()
        {
            var hotel = new Hotel
            {
                Id = "H1",
                Name = "Hotel California",
                Rooms = new List<Room>
                {
                    new Room { RoomType = "SGL", RoomId = "101" },
                    new Room { RoomType = "SGL", RoomId = "102" },
                    new Room { RoomType = "DBL", RoomId = "201" },
                    new Room { RoomType = "DBL", RoomId = "202" }
                }
            };

            var bookings = new List<Booking>
            {
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 1),
                    Departure = new DateOnly(2024, 9, 2),
                    RoomType = "SGL",
                    RoomRate = "Standard"
                }
            };

            string hotelId = "H1";
            string roomType = "SGL";
            var arrival = new DateOnly(2024, 9, 2);
            var departure = new DateOnly(2024, 9, 3);

            _hotelServiceMock.Setup(hs => hs.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure))
                             .Returns(2);

            int availableRoomsCount = _hotelService.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure);

            Assert.Equal(2, availableRoomsCount);
        }

        [Fact]
        public void GetAvailableRooms_WhenRequestedRoomTypeHasNoBookings_ReturnsTotalAvailableRooms()
        {
            var hotel = new Hotel
            {
                Id = "H1",
                Name = "Hotel California",
                Rooms = new List<Room>
                {
                    new Room { RoomType = "SGL", RoomId = "101" },
                    new Room { RoomType = "SGL", RoomId = "102" },
                    new Room { RoomType = "DBL", RoomId = "201" },
                    new Room { RoomType = "DBL", RoomId = "202" }
                }
            };

            var bookings = new List<Booking>
            {
                new Booking
                {
                    HotelId = "H1",
                    Arrival = new DateOnly(2024, 9, 1),
                    Departure = new DateOnly(2024, 9, 3),
                    RoomType = "DBL",
                    RoomRate = "Prepaid"
                }
            };

            string hotelId = "H1";
            string roomType = "SGL";
            var arrival = new DateOnly(2024, 9, 3);
            var departure = new DateOnly(2024, 9, 4);

            _hotelServiceMock.Setup(hs => hs.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure))
                             .Returns(2);

            int availableRoomsCount = _hotelService.GetAvailableRooms(hotel, bookings, hotelId, roomType, arrival, departure);

            Assert.Equal(2, availableRoomsCount);
        }
    }
}