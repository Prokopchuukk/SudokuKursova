using SudokuKursova.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Service
{
    internal class UsersService:IUsersService
    {
        private IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public void CreateUser(string username, string password)
        {
            if (_usersRepository.ReadUserByName(username) == null)
            {
                var newUser = new User(username, password);

                _usersRepository.CreateUser(newUser);
            }
            else
            {
                Console.WriteLine("Username is already exist");
            }
        }
        public void UpdateUser(int id, string username, string password)
        {
            var updatedUser=_usersRepository.ReadUserById(id);
            if(updatedUser != null)
            {
                if (_usersRepository.ReadUserByName(username) != null)
                {
                    if (_usersRepository.ReadUserByName(username).Id != updatedUser.Id)
                    {
                        Console.WriteLine("Username is already exist");
                    }
                    else
                    {
                        _usersRepository.UpdateUser(id, updatedUser);
                    }
                }
                else
                {
                    _usersRepository.UpdateUser(id, updatedUser);
                }
            }
        }

        public void DeleteUser(int id)
        {
            if (_usersRepository.ReadUserById(id) != null)
            {
                _usersRepository.DeleteUser(id);
            }
        }
        public User ReadUserById(int id)
        {
            return _usersRepository.ReadUserById(id);
        }
        public User ReadUserByName(string username)
        {
            return _usersRepository.ReadUserByName(username);
        }
        public bool IsExist(string username, string password)
        {
            var loginUser = _usersRepository.ReadUserByName(username);
            if (loginUser != null && loginUser.Password == password) {
                return true;
            }
            return false;
        }
    }
}
