using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SudokuKursova
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Password { get; set; }
        public static int idCounter=0;
        public User() {
            ++idCounter;
            Id = idCounter;
            Name = "";
            Password = "";
        }
        public User(string name, string password)
        {
            ++idCounter;
            Id = idCounter;
            Name = name;
            Password = password;
        }
    }
}
