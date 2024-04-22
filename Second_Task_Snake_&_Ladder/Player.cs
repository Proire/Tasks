using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Snake___Ladder
{

    internal class SnakeAndLadder
    {
        public  int[] Board { get; set; } = new int[101];

        public readonly Player playerOne;
        public readonly Player playerTwo;
        public Player CurrentPlayer;
        public readonly Random random = new Random();
        public bool RollAgain { get; set; } = false;
        public int Count { get; set; } = 0;

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

                Board[i] = i;
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
            Count++;
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
            // stopping Player from going above 100 
            if (currentPosition + roll > 100)
                return currentPosition;
            int newPosition = currentPosition + roll;
            if (newPosition == 6 || newPosition == 77)
                RollAgain = true;
            int newSquare;
            if (newPosition == 6 || newPosition == 23 || newPosition == 45 || newPosition == 61 || newPosition == 77 || newPosition==98 || newPosition==65)
                newSquare = newPosition + Board[newPosition];
            else
                newSquare = newPosition;
            return newSquare > 100 ? currentPosition : newSquare;
        }

        public void print()
        {

            int alt = 0; // to switch between the alternate nature of the board
            int iterLR = 101; // iterator to print from left to right
            int iterRL = 80;  // iterator to print from right to left
            int val = 100;

            while (val-- > 0)
            {
                if (alt == 0)
                {
                    iterLR--;
                    if (iterLR == playerOne.PlayerPosition)
                    {
                        Console.Write("#P1    ");
                    }
                    else if (iterLR == playerTwo.PlayerPosition)
                    {
                        Console.Write("#P2    ");
                    }
                    else
                    {
                        Console.Write(Board[iterLR] + "    ");
                    }

                    if (iterLR % 10 == 1)
                    {
                        Console.WriteLine("\n\n");
                        alt = 1;
                        iterLR -= 10;
                    }
                }
                else
                {
                    iterRL++;
                    if (iterRL == playerOne.PlayerPosition)
                    {
                        Console.Write("#P1    ");
                    }
                    else if (iterRL == playerTwo.PlayerPosition)
                    {
                        Console.Write("#P2    ");
                    }
                    else
                    {
                        Console.Write(Board[iterRL] + "    ");
                    }

                    if (iterRL % 10 == 0)
                    {
                        Console.WriteLine("\n");
                        alt = 0;
                        iterRL -= 30;
                    }
                }
                if (iterRL == 10)
                    break;
            }
            Console.WriteLine();
        }

        public bool CheckWin()
        {
            return CurrentPlayer.PlayerPosition == 100;
        }
    }

    internal class Player(string name)
    {
        public string Name { get; set; } = name;

        public int PlayerPosition { get; set; } = 0;

    }
}


