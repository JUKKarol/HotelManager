using HotelManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManager.Services;

internal class HotelService
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
}