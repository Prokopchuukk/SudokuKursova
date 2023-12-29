using SudokuKursova.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Command
{
    internal class ExitGameCommand:ICommand
    {
        private IGameService gameService;
        private Game game;
        public ExitGameCommand(IGameService gameservice,Game game)
        {
            this.gameService = gameservice;
            this.game = game;
        }

        public void Execute()
        {
            gameService.AddGame(game);
        }

        public string ShowName()
        {
            return "Exit from game";
        }
    }
}
