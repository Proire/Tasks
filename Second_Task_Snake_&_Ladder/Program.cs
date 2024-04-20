using System.Numerics;

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
            Player PlayerTwo = getPlayer(2);

            // Current Player chance of playing 
            string currentPlayer = playerOne.Name;

            Console.WriteLine($"Name of the Current Player Playing is {currentPlayer}");
            Console.WriteLine($"Position of the Current Player Playing is {playerOne.PlayerPosition}");

            // terminating condition for the game 
            bool win = false;

            // if not win yet then continue with the game 
            while (!win)
            {
                Console.WriteLine($"Player {currentPlayer}, press Enter to roll the die.. ");
                // Hold console for Player until press Enter 
                Console.ReadKey(true);

                // Dice face value 
                int roll = rollDie();

                Console.WriteLine($"You Rolled a {roll}");

                win = true;
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
                    return new Player(player, 0);
                }
            }
            while (true);
        }

        static int rollDie()
        {
            // Random Generator intialization 
            Random random = new Random((int)DateTime.Now.Ticks);

            // Returns an Integer
            return (random.Next() % 6) + 1;
        }
    }
}
