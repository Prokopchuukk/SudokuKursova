using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Service
{
    internal interface IGameService
    {
        void AddGame(Game game);
        void DeleteGame(int Id);
        Game ReadGame(int Id);
        List<Game> ReadAllGamesByUserId(int UserId);
    }
}
