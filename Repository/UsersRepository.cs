using SudokuKursova.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SudokuKursova.Repository
{
    internal class UsersRepository : IUsersRepository
    {
        private DbContext dbContext;
        public UsersRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(User user)
        { 
            dbContext.Users.Add(user);
        }

        public void DeleteUser(int Id)
        {
            var deleteUser = dbContext.Users.FirstOrDefault(u=>u.Id==Id);
            if (deleteUser != null)
            {
                dbContext.Users.Remove(deleteUser);
            }
        }

        public User ReadUserById(int Id)
        {
            var searchUser = dbContext.Users.FirstOrDefault(u => u.Id == Id);
            return searchUser;
        }
        public User ReadUserByName(string name)
        {
            var searchUser = dbContext.Users.FirstOrDefault(u => u.Name == name);
            return searchUser;
        }

        public void UpdateUser(int Id,User user)
        {
            var updateUser = dbContext.Users.FirstOrDefault(u => u.Id == Id);
            if (updateUser != null)
            {
                dbContext.Users.Remove(updateUser);
                dbContext.Users.Add(user);
            }
        }
    }
}
