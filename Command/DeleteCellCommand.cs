using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class DeleteCellCommand : ICommand
    {
        private Field field;
        public DeleteCellCommand(Field field)
        {
            this.field = field;
        }
        public void Execute()
        {
            int x = -1;
            do
            {
                Console.WriteLine("Input x coordinate:");
                x = Convert.ToInt32(Console.ReadLine());
                if (x < 0 || x > 9)
                {
                    Console.WriteLine("Coordinate must be x < 0 or x > 9");
                }
            } while (x < 0 || x > 9);
            int y = -1;
            do
            {
                Console.WriteLine("Input x coordinate:");
                y = Convert.ToInt32(Console.ReadLine());
                if (y < 0 || y > 9)
                {
                    Console.WriteLine("Coordinate must be y < 0 or y > 9");
                }
            } while (y < 0 || y > 9);
            field.DeleteCell(x, y);
        }

        public string ShowName()
        {
           return "Delete Cell";
        }
    }
}
