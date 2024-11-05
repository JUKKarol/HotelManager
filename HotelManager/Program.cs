using System.Text.Json;
using System;
using HotelManager.Entities;
using Microsoft.Extensions.DependencyInjection;
using HotelManager.Services.HotelService;
using HotelManager.Services.BookingService;

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
            .BuildServiceProvider();

        var hotelService = services.GetService<IHotelService>();
        var bookingService = services.GetService<IBookingService>();

        var hotels = hotelService.GetHotels(hotelsJsonPath);
        var bookings = bookingService.GetBooking(bookingsJsonPath);

        foreach (var booking in bookings)
        {
            Console.WriteLine($"hotelId: {booking.HotelId}");
            Console.WriteLine($"arrival: {booking.Arrival}");
            Console.WriteLine($"departure: {booking.Departure}");
            Console.WriteLine($"roomType: {booking.RoomType}");
            Console.WriteLine($"roomRate: {booking.RoomRate}");
        }
    }
}