using SudokuKursova.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class InputCellCommand : ICommand
    {
        private Field field;
        public InputCellCommand(Field field)
        {
            this.field=field;
        }
        public void Execute() {
            
            int x = -1;
            do
            {
                Console.WriteLine("Input x coordinate:");
                x = Convert.ToInt32(Console.ReadLine());
                if(x < 0 || x > 9)
                {
                    Console.WriteLine("Coordinate must be x < 0 or x > 9");
                }
            } while (x < 0 || x > 9);
            int y = -1;
            do
            {
                Console.WriteLine("Input y coordinate:");
                y = Convert.ToInt32(Console.ReadLine());
                if (y < 0 || y > 9)
                {
                    Console.WriteLine("Coordinate must be y < 0 or y > 9");
                }
            } while (y < 0 || y > 9);
            int value = -1;
            do
            {
                Console.WriteLine("Input value:");
                value = Convert.ToInt32(Console.ReadLine());
                if (value < 1 || value > 9)
                {
                    Console.WriteLine("Value must be value < 0 or value > 9");
                }
            } while (value < 1 || value > 9);
            if(field.InputCell(value, x, y))
            {
                Console.WriteLine("Value is assigned");
            }
            else
            {
                Console.WriteLine("Value is not assigned - there is already such a value on the row or column");
            }

        }
        public string ShowName()
        {
            return "Input cell";
        }
    }
}
