using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SudokuKursova.Repository
{
    internal interface IUsersRepository
    {
        void CreateUser(User user);
        void UpdateUser(int Id,User user);
        void DeleteUser(int Id);
        User ReadUserById(int Id);
        User ReadUserByName(string name);
    }
}
