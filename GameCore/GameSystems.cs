using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public abstract class GameSystems
    {
        protected Board board;

        Player[] players;
        Player activePlayer;

        protected abstract void Start();
        protected abstract bool GameOver();

        protected void GameLoop()
        {
            int indexOfCurrentPlayer = 0;
            activePlayer = players[indexOfCurrentPlayer];

            while (!GameOver())
            {
                Console.WriteLine("Here is the board:");
                PrintBoard();

                TakeTurn(activePlayer);
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                activePlayer = players[indexOfCurrentPlayer];

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                System.Threading.Thread.Sleep(300);

                Console.Clear();
            }
        }

        protected void TakeTurn(Player activePlayer)
        {
            int[] position = PiecePlacement(activePlayer);
            board.setSquare(position[0], position[1], activePlayer.Token);
        }

        protected void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row <= board.Squares.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.Squares.GetUpperBound(1); column++)
                {
                    Console.Write(board.Squares[row, column]);

                    //only print the dashes for the inner columns
                    if (column < board.Squares.GetUpperBound(1))
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }
        protected void PrintBoardMap()
        {
            int position = 1; //1-based board map (done for user experience)

            for (int row = 0; row <= board.Squares.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.Squares.GetUpperBound(1); column++)
                {
                    Console.Write(position++);
                    if (column < board.Squares.GetUpperBound(1))
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int[] ConvertToArrayLocation(string boardPosition)
        {
            int position = Int32.Parse(boardPosition);
            position--; //reduce position to account for 1-based board map (done for user experience)
            int row = position / 3;
            int column = position % 3;
            return new int[] { row, column }; //inline array initialization
        }

        private int[] PiecePlacement(Player activePlayer)
        {
            //you need to be using the .NET framework 4.6 for this line to work (C# 6)
            Console.WriteLine();
            Console.WriteLine($"{activePlayer.Name}, it's your turn:");
            Console.WriteLine("Make your move by entering the number of the sqaure you'd like to take:");
            PrintBoardMap();
            Console.Write("Enter the number: ");

            //todo: Prevent returning a location that's already been used

            return ConvertToArrayLocation(Console.ReadLine());
        }
    }
}
