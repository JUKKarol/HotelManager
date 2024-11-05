using HotelManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManager.Services.HotelService;

public class HotelService : IHotelService
{
    public List<Hotel> GetHotels(string jsonPath)
    {
        try
        {
            string jsonData = File.ReadAllText(jsonPath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Hotel> hotels = JsonSerializer.Deserialize<List<Hotel>>(jsonData, options);

            return hotels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    public void PrintHotels(List<Hotel> hotels)
    {
        Console.WriteLine("****************************");
        Console.WriteLine("Hotels:");
        Console.WriteLine("****************************");

        foreach (var hotel in hotels)
        {
            Console.WriteLine($"Hotel ID: {hotel.Id}");
            Console.WriteLine($"Name: {hotel.Name}");
            Console.WriteLine("Room Types:");
            foreach (var roomType in hotel.RoomTypes)
            {
                Console.WriteLine($"Code: {roomType.Code}");
                Console.WriteLine($"Description: {roomType.Description}");
                Console.WriteLine($"Amenities: {string.Join(", ", roomType.Amenities)}");
                Console.WriteLine($"Features: {string.Join(", ", roomType.Features)}");
            }
            Console.WriteLine("Rooms:");
            foreach (var room in hotel.Rooms)
            {
                Console.WriteLine($"Room Type: {room.RoomType}");
                Console.WriteLine($"Room Rate: {room.RoomId}");
            }

            Console.WriteLine("----------------------------");
        }
    }

    public int GetAvailableRooms(Hotel hotel, List<Booking> bookings, string hotelId, string roomType, DateOnly arrival, DateOnly departure)
    {
        if (hotel == null)
        {
            return 0;
        }

        var targetRooms = hotel.Rooms.Where(r => r.RoomType == roomType).ToList();

        int bookedRoomsCount = bookings.Count(b =>
            b.HotelId == hotelId &&
            b.RoomType == roomType &&
            (arrival <= b.Departure && departure >= b.Arrival)
        );

        int availableRoomsCount = targetRooms.Count - bookedRoomsCount;

        return Math.Max(availableRoomsCount, 0);
    }
}