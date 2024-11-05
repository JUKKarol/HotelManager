using HotelManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services.BookingService;

internal interface IBookingService
{
    List<Booking> GetBooking(string jsonPath);
}