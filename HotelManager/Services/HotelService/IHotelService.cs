using HotelManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services.HotelService;

internal interface IHotelService
{
    List<Hotel> GetHotels(string jsonPath);

    void PrintHotels(List<Hotel> hotels);
}