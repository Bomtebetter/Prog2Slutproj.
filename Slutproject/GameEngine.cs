using System;
using System.Collections.Generic;
using System.Text;

namespace Slutproject
{
    public class GameEngine
    {
        private readonly char[,] board;
        private readonly int dimension;

        public void NewGame()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        public GameEngine(int dimension)
        {
            board = new char[dimension, dimension];
            NewGame();

            this.dimension = dimension;
        }

        public char[,] Board => board;

        public (int x, int y)[] GetWinVector(object clickedPosition)
        {
            var vector = FindHorizontalWinVector();
            if (vector != null) return vector;

            vector = FindVerticalWinVector();
            if (vector != null) return vector;

            return FindDiagonalWinVector();
        }

        private (int x, int y)[] FindDiagonalWinVector()
        {
            return null;
        }

        private (int x, int y)[] FindHorizontalWinVector()
        {

            var vector = FindHorizontalWinVector('X');
            if (vector != null) return vector;

            return FindHorizontalWinVector('O');

        }

        private (int x, int y)[] FindHorizontalWinVector(char v)
        {
            (int x, int y)[] result = new (int, int)[3] ;

            //check each row
            for (int row = 0; row < dimension; row++)
            {
                int counter = 0;
                //search for three in line in a col
                for (int col = 0; col < dimension; col++)
                {
                    if (board[col,row] == v)
                    {
                        result[counter] = (col,row);
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
            var vector = FindVerticalWinVector('X');
            if (vector != null) return vector;

            return FindVerticalWinVector('O');
        }

        private (int x, int y)[] FindVerticalWinVector(char v)
        {
            (int x, int y)[] result = new (int, int)[3];

            //check each col
            for (int col = 0; col < dimension; col++)
            {
                int counter = 0;
                //search for three in line in a row
                for (int row = 0; row < dimension; row++)
                {
                    if (board[col, row] == v)
                    {
                        result[counter] = (col, row);
                        counter++;
                        if (counter == 3) return result;
                    }
                    else
                    {
                        counter = 0;
                    }
                }
            }
            return null;
        }

        public void SetPosition(int x, int y, char marker)
        {
            board[x, y] = marker;
        }
    }
}
