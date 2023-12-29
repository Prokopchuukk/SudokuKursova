using SudokuKursova.Command;
using SudokuKursova.DataBase;
using SudokuKursova.Repository;
using SudokuKursova.Service;

namespace SudokuKursova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContext dbContext = new DbContext();
            IGameRepository gameRepository = new GameRepository(dbContext);
            IUsersRepository usersRepository = new UsersRepository(dbContext);

            IGameService gameService = new GameService(gameRepository);
            IUsersService usersService = new UsersService(usersRepository);
            User user = null;
            bool Continue = true;
            List<ICommandAccount> CommandsRegistration =
            [
                new AuthorizationCommand(usersService),
                new RegistrationCommand(usersService),
            ];
            while (Continue)
            {
                bool gamePlayed = true;
                bool StartGame = false;
                int choice;
                while (user == null && Continue)
                {
                    do
                    {
                        Console.WriteLine("Choice command:\nAll command:");
                        for (int i = 0; i < CommandsRegistration.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1} - {CommandsRegistration[i].ShowName()}");
                        }
                        Console.WriteLine("0 - Exit");
                        choice = Convert.ToInt32(Console.ReadLine());
                    } while (choice < 0 || choice > CommandsRegistration.Count());

                    if (choice != 0)
                    {
                        user = CommandsRegistration[choice - 1].Execute();
                        if (user == null)
                        {
                            Console.WriteLine("Incorrect data");
                        }
                    }
                    else
                    {
                        Continue = false;
                    }
                }
                Game game = null;
                while (!StartGame && Continue)
                {
                    List<ICommand> CommandsStartOrPrintGame = [new PrintAllGameCommand(gameService, user.Id)];
                    do
                    {
                        Console.WriteLine("Choice command:\nAll command:");
                        for (int i = 0; i < CommandsStartOrPrintGame.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1} - Command {CommandsStartOrPrintGame[i].ShowName()}");
                        }
                        Console.WriteLine("2 - Start Game");
                        Console.WriteLine("3 - Log out");
                        Console.WriteLine("0 - Exit");
                        choice = Convert.ToInt32(Console.ReadLine());
                    } while (choice < 0 || choice >3);

                    if (choice ==1)
                    {
                        CommandsStartOrPrintGame[choice - 1].Execute();
                    }
                    if (choice == 2)
                    {
                        game = new StartGameCommand(user).Execute();
                        StartGame = true;
                    }
                    if (choice == 3)
                    {
                        user = null;
                        StartGame = true;
                        gamePlayed = false;
                    }
                    if (choice == 0) { 
                        Continue = false;
                    }  
                } 
                while (gamePlayed && Continue)
                {
                    List<ICommand> CommandsGame =
                    [
                        new InputCellCommand(game.field),
                        new DeleteCellCommand(game.field),
                        new ExitGameCommand(gameService, game)
                    ];
                    do
                    {
                        game.field.Print();
                        Console.WriteLine("Choice command:\nAll command:");
                        for (int i = 0; i < CommandsGame.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1} - Command {CommandsGame[i].ShowName()}");
                        }
                        Console.WriteLine("0 - Exit");
                        choice = Convert.ToInt32(Console.ReadLine());
                    } while (choice < 0 || choice > CommandsGame.Count());

                    if (choice != 0)
                    {
                        CommandsGame[choice - 1].Execute();
                        if (game.isGameWin())
                        {
                            CommandsGame[CommandsGame.Count() - 1].Execute();
                            Console.WriteLine("Congratulations you have won!!!");
                            gamePlayed = true;
                        }
                        if (choice == CommandsGame.Count)
                        {
                            gamePlayed = false;
                        }
                    }
                    else
                    {
                        Continue = false;
                    }
                }
            }
        }
    }
}
