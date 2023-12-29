using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.DataBase
{
    internal class DbContext
    {
        private List<User> users = new List<User>();
        private List<Game> games = new List <Game> ();
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public List<Game> Games
        {
            get { return games; }
            set { games = value; }
        }
    }
}
