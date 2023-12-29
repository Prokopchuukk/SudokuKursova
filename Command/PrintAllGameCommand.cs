using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuKursova.Service;
namespace SudokuKursova.Command
{
    internal class PrintAllGameCommand : ICommand
    {
        private IGameService _gameService;
        private int userId;
        public PrintAllGameCommand(IGameService gameService,int userId)
        {
            _gameService = gameService;
            this.userId = userId;
        }
        public void Execute()
        {
            var allGame=_gameService.ReadAllGamesByUserId(userId);
            foreach(var game in allGame)
            {
                string outcome = game.IsWin ? "Win" : "Lose";
                Console.WriteLine($"Id:{game.Id} Result:{outcome} Rating:{game.rating}");
            }
        }

        public string ShowName()
        {
            return "Print all user games";
        }
    }
}
