using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services.UserService;

internal interface IUserService
{
    string GetInput(string prompt);
}