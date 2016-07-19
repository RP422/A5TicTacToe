using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCore;

namespace TicTacToe
{
    public class TicTac : GameSystems
    {
        static void Main(string[] args)
        {
            TicTac p = new TicTac();
            p.Start();
        }

        Player activePlayer;
        Player[] players;

        public TicTac()
        {
            players = new Player[2];

            //Random names from http://www.behindthename.com/random/ 
            //The names are Greek ;)
            players[0] = new Player() { Name = "Player 1: Bismuth", Token = 'X' }; //using object initialization syntax
            players[1] = new Player() { Name = "Player 2: Xenon", Token = 'O' };  
        }


        /// <summary>
        /// The Tic Tac Toe game loop, 2 players.  Iterate player turns until the game
        /// is over
        /// </summary>
        protected override void Start()
        {
            GameLoop();
        }

        /// <summary>
        /// You didn't think I'd write every method for you, did you?
        /// </summary>
        /// <returns></returns>
        protected override bool GameOver()
        {
            return (CheckHorizontal() || CheckVertical() || CheckDiagonal());
        }

        private bool CheckHorizontal()
        {
            char token;
            bool check = false;

            for (int row = 0; row <= board.Squares.GetUpperBound(0); row++)
            {
                token = board.Squares[row, 0];

                for (int column = 1; column <= board.Squares.GetUpperBound(1); column++)
                {
                    if(board.Squares[row, column] != token)
                    {
                        break;
                    }
                    else if(column == board.Squares.GetUpperBound(1))
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    break;
                }
            }

            return check;
        }
        private bool CheckVertical()
        {
            char token;
            bool check = false;

            for (int column = 0; column <= board.Squares.GetUpperBound(1); column++)
            {
                token = board.Squares[0, column];

                for (int row = 1; row <= board.Squares.GetUpperBound(0); row++)
                {
                    if (board.Squares[row, column] != token)
                    {
                        break;
                    }
                    else if (row == board.Squares.GetUpperBound(0))
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    break;
                }
            }

            return check;
        }
        private bool CheckDiagonal()
        {
            char token = board.Squares[0, 0];
            bool check = false;

            for (int x = 1; x <= board.Squares.GetUpperBound(0); x++)
            {
                if (board.Squares[x, x] != token)
                {
                    break;
                }
                else if (x == board.Squares.GetUpperBound(0))
                {
                    check = true;
                }
            }

            if(!check)
            {
                token = board.Squares[0, board.Squares.GetUpperBound(0)];

                for (int x = 1; x <= board.Squares.GetUpperBound(0); x++)
                {
                    if (board.Squares[x, board.Squares.GetUpperBound(0) - x] != token)
                    {
                        break;
                    }
                    else if (x == board.Squares.GetUpperBound(0))
                    {
                        check = true;
                    }
                }
            }

            return check;
        }
    }

    

}
