using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Repository
{
    internal interface IGameRepository
    {
        void CreateGame(Game game);
        List<Game> ReadAllGamesByUserId(int UserId);
        void UpdateGame(int Id,Game game);
        void DeleteGame(int Id);

        Game ReadGame(int Id);
    }
}
