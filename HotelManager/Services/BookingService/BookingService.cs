using HotelManager.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManager.Services.BookingService;

internal class BookingService : IBookingService
{
    public List<Booking> GetBooking(string jsonPath)
    {
        try
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var bookings = JsonSerializer.Deserialize<List<Booking>>(File.ReadAllText(jsonPath), options);

            foreach (var booking in bookings)
            {
                booking.Arrival = DateOnly.ParseExact(booking.ArrivalDateString, "yyyyMMdd");
                booking.Departure = DateOnly.ParseExact(booking.DepartureDateString, "yyyyMMdd");
            }

            return bookings;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public void PrintBookings(List<Booking> bookings)
    {
        Console.WriteLine("****************************");
        Console.WriteLine("Bookings:");
        Console.WriteLine("****************************");

        foreach (var booking in bookings)
        {
            Console.WriteLine($"Hotel ID: {booking.HotelId}");
            Console.WriteLine($"Arrival: {booking.Arrival}");
            Console.WriteLine($"Departure: {booking.Departure}");
            Console.WriteLine($"Room Type: {booking.RoomType}");
            Console.WriteLine($"Room Rate: {booking.RoomRate}");
            Console.WriteLine("----------------------------");
        }
    }
}