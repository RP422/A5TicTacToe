﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public abstract class GameSystems
    {
        private Board board;

        Player[] players;
        Player activePlayer;

        private void TakeTurn(Player activePlayer)
        {
            int[] position = PiecePlacement(activePlayer);
            board.setSquare(position[0], position[1], activePlayer.Token);
        }

        private void PrintBoard()
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
        private void PrintBoardMap()
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