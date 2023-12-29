using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova
{
    internal class Game
    {
        public int Id { get; set; }
        public Field field { get; set; }
        public int UserId { get; set; }
        public static int idCounter = 0;
        public bool IsWin {get; set;}
        public int rating { get; set; }

        public Game(Field field, int UserId, int rating, bool IsWin)
        {
            ++idCounter;
            Id = idCounter;
            this.UserId = UserId;
            this.field = field;
            this.IsWin = IsWin;
            this.rating = rating;
        }
        public bool isGameWin()
        {
            if (field.IsFullyFilled())
            {
                IsWin = true;
                return true;
            }
            return false;
        }
    }
}
