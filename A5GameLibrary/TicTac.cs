using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTac : GameCore.GameSystems
    {
        static void Main(string[] args)
        {
            TicTac p = new TicTac();
            p.Start();
        }


        Player activePlayer;
        char[,] board = new char[3,3];
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
        private void Start()
        {
            int indexOfCurrentPlayer = 0;
            activePlayer = players[indexOfCurrentPlayer];

            while (!GameOver())
            {
                Console.WriteLine("Here is the board:");
                base.PrintBoard();

                base.TakeTurn(activePlayer);
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                activePlayer = players[indexOfCurrentPlayer];

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                System.Threading.Thread.Sleep(300);

                Console.Clear();
            }
        }

        /// <summary>
        /// You didn't think I'd write every method for you, did you?
        /// </summary>
        /// <returns></returns>
        private bool GameOver()
        {
            //if three in a row or all spaces are filled
            return false;
        }
    }

    

}
