using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services.UserService;

internal class UserService : IUserService
{
    public string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"{prompt.Replace(":", "")} is required.");
            Environment.Exit(0);
        }
        return input;
    }
}