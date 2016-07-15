using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class Board
    {
        public char[,] Squares { get; private set; }
//        public int Length { get; private set; }
//        public int Height { get; private set; }

        public Board(int sideLength)
        {
            Squares = new char[sideLength, sideLength];
        }
        public Board(int Length, int Height)
        {
            Squares = new char[Length, Height];
        }

        public void setSquare(int x, int y, char token)
        {
            Squares[x, y] = token;
        }
    }
}