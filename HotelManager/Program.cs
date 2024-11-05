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
        string departureString = userService.GetInput("departure (yyyymmdd):");
        DateOnly departure = DateOnly.ParseExact(departureString, "yyyyMMdd");
        string roomType = userService.GetInput("room type:");

        var existingRooms = hotels.FirstOrDefault(h => h.Id == hotelId)?.Rooms.Where(r => r.RoomType == roomType).ToList();

        if (existingRooms == null)
        {
            Console.WriteLine("Hotel or room not found.");
        }
    }
}