using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SudokuKursova.Service
{
    internal interface IUsersService
    {
        void CreateUser(string username, string password);
        void UpdateUser(int id,string username, string password);
        void DeleteUser(int id);
        User ReadUserById(int id);
        User ReadUserByName(string username);
        bool IsExist(string username,string password);

    }
}
