using System.Text.Json;
using System;
using HotelManager.Entities;
using HotelManager.Services;

namespace HotelManager;

internal class Program
{
    private static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

        string hotelsJson = Path.Combine(projectDirectory, "hotels.json");

        var hotelService = new HotelService();

        List<Hotel> hotels = hotelService.GetHotels(hotelsJson);

        foreach (var hotel in hotels)
        {
            Console.WriteLine($"Hotel: {hotel.Name}");

            foreach (var room in hotel.Rooms)
            {
                Console.WriteLine($"Room: {room.RoomId}");
            }
        }
    }
}