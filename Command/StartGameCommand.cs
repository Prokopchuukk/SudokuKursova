using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class StartGameCommand
    {
        private User user;
        public StartGameCommand(User user)
        {
            this.user = user;
        }
        public Game Execute()
        {
            int rating=-1;
            do
            {
                Console.WriteLine("Input rating game:");
                rating = Convert.ToInt32(Console.ReadLine());
            } while (rating < 0);
            int countFillCell=-1;
            do
            {
                Console.WriteLine("Input count fill cell from 0 to 81:");
                countFillCell = Convert.ToInt32(Console.ReadLine());
            } while (countFillCell < 0 || countFillCell > 81);
            var field = new Field();
            field.GenerateSudoku(countFillCell);
            return new Game(field, user.Id, rating, false);
        }
    }
}
