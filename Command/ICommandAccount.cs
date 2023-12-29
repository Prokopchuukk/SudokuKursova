using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal interface ICommandAccount
    {
        User Execute();
        string ShowName();
    }
}
