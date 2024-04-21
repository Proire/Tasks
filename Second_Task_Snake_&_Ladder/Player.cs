using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Snake___Ladder
{

    internal class SnakeAndLadder
    {
        public  int[] Board { get; set; } = new int[101];

        public readonly Player playerOne;
        public readonly Player playerTwo;
        public readonly Player CurrentPlayer;
        public readonly Random random = new Random();

        public SnakeAndLadder(Player currentPlayer, Player player1, Player player2)
        {
            CurrentPlayer = currentPlayer;
            playerOne = player1;
            playerTwo = player2;
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 1; i <= 100; i++)
            {
                Board[i] = 0;
            }

            // Define the positions of snakes and ladders
            Board[6] = 40;
            Board[23] = -10;
            Board[45] = -7;
            Board[61] = -18;
            Board[65] = -8;
            Board[77] = 5;
            Board[98] = -10;
        }

        public int RollDie()
        {
            
            return random.Next(1, 7);
        }

        public void MovePlayer(Player player)
        {
            int roll = RollDie();
            Console.WriteLine($"You rolled a {roll}.");
            player.PlayerPosition = MovePlayerPosition(player.PlayerPosition, roll);
            Console.WriteLine($"Player {player.Name} is now at square {player.PlayerPosition}.\n\n");
        }

        private int MovePlayerPosition(int currentPosition, int roll)
        {
            int newPosition = currentPosition + roll;
            int newSquare = newPosition + Board[newPosition];
            return newSquare > 100 ? currentPosition : newSquare;
        }

        public bool CheckWin(Player player)
        {
            return player.PlayerPosition == 100;
        }
    }

    internal class Player(string name)
    {
        public string Name { get; set; } = name;

        public int PlayerPosition { get; set; } = 0;

    }
}


