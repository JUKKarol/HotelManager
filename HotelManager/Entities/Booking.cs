﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Entities;

internal class Booking
{
    public string HotelId { get; set; }
    public string Arrival { get; set; }
    public string Departure { get; set; }
    public string RoomRate { get; set; }
}