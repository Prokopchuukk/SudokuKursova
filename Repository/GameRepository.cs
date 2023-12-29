using SudokuKursova.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuKursova.Repository
{
    internal class GameRepository : IGameRepository
    {
        private DbContext dbContext;
        public GameRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateGame(Game game)
        {
            dbContext.Games.Add(game);
        }

        public void DeleteGame(int Id)
        {
            var deletedGame=dbContext.Games.FirstOrDefault(g=>g.Id==Id);
            if (deletedGame != null)
            {
                dbContext.Games.Remove(deletedGame);
            }
        }

        public List<Game> ReadAllGamesByUserId(int UserId)
        {
            return dbContext.Games.Where(g=>g.UserId==UserId).ToList();
        }
        public Game ReadGame(int Id)
        {
            return dbContext.Games.FirstOrDefault(g=>g.Id==Id);
        }
        public void UpdateGame(int Id, Game game)
        {
            var updatedGame = dbContext.Games.FirstOrDefault(g => g.Id == Id);
            if(updatedGame != null)
            {
                dbContext.Games.Remove(updatedGame);
                dbContext.Games.Add(game);
            }
        }
    }
}
