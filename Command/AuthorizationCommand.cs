using SudokuKursova.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class AuthorizationCommand: ICommandAccount
    {
        private IUsersService _usersService;
        public AuthorizationCommand(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public User Execute()
        {
            Console.WriteLine("Enter your name:");
            string username=Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password=Console.ReadLine();
            if(_usersService.IsExist(username, password))
            {
                return _usersService.ReadUserByName(username);
            }
            return null;
        }
        public string ShowName()
        {
            return "Authorize";
        }
    }
}
