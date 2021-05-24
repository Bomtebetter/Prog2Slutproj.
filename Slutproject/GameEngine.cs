using System;
using System.Collections.Generic;
using System.Text;

namespace Slutproject
{
    public class GameEngine
    {
        private readonly char[,] board;
        private readonly int dimension;

        public GameEngine(int dimension)
        {
            board = new char[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    board[i, j] = '-';
                }
            }

            this.dimension = dimension;
        }

        public char[,] Board => board;

        public (int x, int y)[] GetWinVector(object clickedPosition)
        {
            return FindHorizontalWinVector();
            return FindDiagonalWinVector();
            return FindVerticalWinVector();
            return null;
        }

        private (int x, int y)[] FindDiagonalWinVector()
        {
            throw new NotImplementedException();
        }

        private (int x, int y)[] FindHorizontalWinVector()
        {

            return FindHorizontalWinVector('X');
            return FindHorizontalWinVector('O');

        }

        private (int x, int y)[] FindHorizontalWinVector(char v)
        {
            int counter = 0;
            (int x, int y)[] result = new (int, int)[3] ;

            //check each row
            for (int i = 0; i < dimension; i++)
            {
                //search for three in line in a row
                for (int j = 0; i < dimension; i++)
                {
                    if (board[j,i] == v)
                    {
                        result[counter] = (j,i);
                        counter++;
                        if (counter == 3) return result;
                    } else
                    {
                        counter = 0;
                    }
                }
            }
            return null;
        }

        private (int x, int y)[] FindVerticalWinVector()
        {
            throw new NotImplementedException();
        }

        public void SetPosition(int x, int y, char marker)
        {
            board[x, y] = marker;
        }
    }
}
