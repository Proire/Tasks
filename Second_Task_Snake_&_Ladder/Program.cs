using System.Numerics;
using System.Runtime.InteropServices;

namespace Second_Task_Snake___Ladder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Snake and Ladder Game Simulator!");

            Console.WriteLine("Game Starts ");

            // Creating two Players
            Player playerOne = getPlayer(1);
            Player playerTwo = getPlayer(2);

            // Current Player playing the Game 
            Player currentPlayer = new Player(playerOne.Name);

            // Intialize the Game 
            SnakeAndLadder snakeandladder = new SnakeAndLadder(currentPlayer, playerOne, playerTwo);

            Console.WriteLine($"Name of the Current Player Playing is {snakeandladder.CurrentPlayer.Name}");
            Console.WriteLine($"Position of the Current Player Playing is {snakeandladder.CurrentPlayer.PlayerPosition}");

            // terminating condition for the game 
            bool Win = false;

            // if not win yet then continue with the game 
            while (!Win)
            {
                Console.WriteLine($"Player {snakeandladder.CurrentPlayer.Name}, press Enter to roll the die.. ");
                // Hold console for Player until press Enter 
                Console.ReadKey(true);

                if (snakeandladder.CurrentPlayer.Name.Equals(playerOne.Name))
                {
                    snakeandladder.MovePlayer(snakeandladder.CurrentPlayer);
                    Console.WriteLine($"{snakeandladder.playerOne.Name} is now at {snakeandladder.playerOne.PlayerPosition}");
                }
                else
                {
                    snakeandladder.MovePlayer(snakeandladder.CurrentPlayer);
                    Console.WriteLine($"{snakeandladder.playerOne.Name} is now at {snakeandladder.playerOne.PlayerPosition}");
                }
                snakeandladder.CurrentPlayer.Name = (snakeandladder.CurrentPlayer.Name.Equals(playerOne.Name)) ? playerTwo.Name : playerOne.Name;
            }
        }

        static Player getPlayer(int rank)
        {

            do
            {
                Console.WriteLine("Enter the name of Player " + rank);
                string? player = Console.ReadLine();
                if (player is not null)
                {
                    return new Player(player);
                }
            }
            while (true);
        }
    }
}
