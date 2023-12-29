using SudokuKursova.DataBase;
using SudokuKursova.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuKursova.Repository;

namespace SudokuKursova.Service
{
    internal class GameService : IGameService
    {
        private IGameRepository GameRepository;
        public GameService(IGameRepository GameRepository)
        {
            this.GameRepository = GameRepository;
        }
        public void AddGame(Game game)
        {
            GameRepository.CreateGame(game);
        }
        public void DeleteGame(int Id)
        {
            GameRepository.DeleteGame(Id);
        }
        public Game ReadGame(int Id)
        {
            return GameRepository.ReadGame(Id);
        }

        public List<Game> ReadAllGamesByUserId(int UserId)
        {
            return GameRepository.ReadAllGamesByUserId(UserId);
        }

    }
}
