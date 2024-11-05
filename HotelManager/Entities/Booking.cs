using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManager.Entities;

public class Booking
{
    public string HotelId { get; set; }

    [JsonIgnore]
    public DateOnly Arrival { get; set; }

    [JsonIgnore]
    public DateOnly Departure { get; set; }

    public string RoomType { get; set; }
    public string RoomRate { get; set; }

    [JsonPropertyName("Arrival")]
    public string ArrivalDateString { get; set; }

    [JsonPropertyName("Departure")]
    public string DepartureDateString { get; set; }
}