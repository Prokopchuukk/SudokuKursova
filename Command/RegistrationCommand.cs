using SudokuKursova.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class RegistrationCommand:ICommandAccount
    {
        private IUsersService _usersService;
        public RegistrationCommand(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public User Execute()
        {
            Console.WriteLine("Enter your name:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            if (_usersService.ReadUserByName(username)!=null)
            {
                Console.Write("User is already exist");
                return null;
            }
            _usersService.CreateUser(username, password);
            return _usersService.ReadUserByName(username);
        }
        public string ShowName()
        {
            return "Sign up";
        }
    }
}
