using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Second_Task_Snake___Ladder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Snake and Ladder Game Simulator!");

            Console.WriteLine("\nGame Starts Now\n");

            // Creating two Players
            Player playerOne = getPlayer(1);
            Player playerTwo = getPlayer(2);

            // spacing only 
            Console.WriteLine();

            // Current Player playing the Game 
            Player currentPlayer = playerOne;

            // Intialize the Game 
            SnakeAndLadder snakeandladder = new SnakeAndLadder(currentPlayer, playerOne, playerTwo);

            Console.WriteLine($"\nName of the Current Player Playing is {snakeandladder.CurrentPlayer.Name}");
            Console.WriteLine($"Position of the Current Player Playing is {snakeandladder.CurrentPlayer.PlayerPosition}");

            // terminating condition for the game 
            bool Win = false;

            // if not win yet then continue with the game 

            while (!Win)
            {
                Console.WriteLine($"\nPlayer {snakeandladder.CurrentPlayer.Name}, press Enter to roll the die.. ");
                // Hold console for Player until press Enter 
                Console.ReadKey(true);

                if (snakeandladder.CurrentPlayer.Name.Equals(playerOne.Name))
                {
                    snakeandladder.MovePlayer(snakeandladder.CurrentPlayer);
                    snakeandladder.print();
                    if (snakeandladder.CheckWin())
                    {
                        Console.WriteLine($"{snakeandladder.CurrentPlayer.Name} has won! Congratulations to you");
                        Win = true;
                        Console.WriteLine($"{snakeandladder.Count} times Dice was Roll");
                    }
                }
                else
                {
                    snakeandladder.MovePlayer(snakeandladder.CurrentPlayer);
                    snakeandladder.print();
                    if (snakeandladder.CheckWin())
                    {
                        Console.WriteLine($"{snakeandladder.CurrentPlayer.Name} has won! Congratulations to you");
                        Win = true;
                        Console.WriteLine($"{snakeandladder.Count} times Dice was Roll");
                    }
                }
                if(!snakeandladder.RollAgain)
                    snakeandladder.CurrentPlayer = (snakeandladder.CurrentPlayer.Name.Equals(playerOne.Name)) ? playerTwo : playerOne;
            }
        }



        static Player getPlayer(int rank)
        {

            do
            {
                Console.Write("Enter the name of Player " + rank+" : ");
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
