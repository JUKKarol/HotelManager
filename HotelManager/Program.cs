using System.Text.Json;
using System;
using HotelManager.Entities;
using Microsoft.Extensions.DependencyInjection;
using HotelManager.Services.HotelService;
using HotelManager.Services.BookingService;
using HotelManager.Services.UserService;

namespace HotelManager;

internal class Program
{
    private static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

        string hotelsJsonPath = Path.Combine(projectDirectory, "hotels.json");
        string bookingsJsonPath = Path.Combine(projectDirectory, "bookings.json");

        var services = new ServiceCollection()
            .AddTransient<IHotelService, HotelService>()
            .AddTransient<IBookingService, BookingService>()
            .AddTransient<IUserService, UserService>()
            .BuildServiceProvider();

        var hotelService = services.GetService<IHotelService>();
        var bookingService = services.GetService<IBookingService>();
        var userService = services.GetService<IUserService>();

        var hotels = hotelService.GetHotels(hotelsJsonPath);
        var bookings = bookingService.GetBooking(bookingsJsonPath);

        hotelService.PrintHotels(hotels);
        bookingService.PrintBookings(bookings);
        Console.WriteLine();

        string hotelId = userService.GetInput("hotel id:");
        string arrivalString = userService.GetInput("arrival (yyyymmdd):");
        DateOnly arrival = DateOnly.ParseExact(arrivalString, "yyyyMMdd");
        Console.WriteLine("Press 'x' if you want to check arrival date only");
        string departureString = userService.GetInput("departure (yyyymmdd):");
        if (departureString == "x")
        {
            departureString = arrivalString;
        }
        DateOnly departure = DateOnly.ParseExact(departureString, "yyyyMMdd");
        string roomType = userService.GetInput("room type:");

        var userTargetHotel = hotels.FirstOrDefault(h => h.Id == hotelId);

        if (userTargetHotel == null)
        {
            Console.WriteLine("Hotel not found.");
            return;
        }
        else
        {
            var userTargetRooms = userTargetHotel.Rooms.FirstOrDefault(r => r.RoomType == roomType);

            if (userTargetRooms == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }
        }

        int availableRoomsCount = hotelService.GetAvailableRooms(userTargetHotel, bookings, hotelId, roomType, arrival, departure);
        Console.WriteLine($"Available rooms: {availableRoomsCount}");
    }
}