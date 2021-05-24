using System;
using System.Collections.Generic;
using System.Text;

namespace Slutproject
{
    public class GameEngine
    {
        private readonly char[,] board;
        private readonly int dimension;
        private bool gameEnabled = true;
        public bool GameEnabled { get => gameEnabled; set => gameEnabled = value; }

        public event EventHandler<WinEventArgs> Winner;

        /// <summary>
        /// Placerar ut '-' i alla knappar så de visar vilka som är spelbara
        /// </summary>
        /// <param name="dimension"></param>
        public void NewGame()
        {
            GameEnabled = true;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        /// <summary>
        /// En konstruktor
        /// </summary>
        public GameEngine(int dimension)
        {
            board = new char[dimension, dimension];
            NewGame();

            this.dimension = dimension;
        }   

        public char[,] Board => board;

        /// <summary>
        /// Kollar igenom alla metoder för att vinna för att kolla ifall man vunnit
        /// </summary>
        /// <returns></returns>
        public (int x, int y)[] GetWinVector(object clickedPosition)
        {
            var vector = FindHorizontalWinVector();
            if (vector != null) return vector;

            vector = FindVerticalWinVector();
            if (vector != null) return vector;

            vector = FindDiagonalWinVectorUp();
            if (vector != null) return vector;

            return FindDiagonalWinVectorDown();
        }

        /// <summary>
        /// gör så att metoden för att kolla ifall man vunnit appliceras på båda spelarna
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private (int x, int y)[] FindDiagonalWinVectorUp()
        {
            var vector = FindDiagonalWinVectorUp('X');
            if (vector != null) return vector;

            return FindDiagonalWinVectorUp('O');
        }

        /// <summary>
        /// Kollar igenom de diagonala punkterna från vänstra nedre hörn för att se ifall man fått 3 irad på diagonalen
        /// </summary>
        /// <returns></returns>
        private (int x, int y)[] FindDiagonalWinVectorUp(char v)
        {
            (int x, int y)[] result = new (int, int)[3];
            if (board[2, 0] == v && board[1, 1] == v && board[0, 2] == v)
            {
                result = new[] { (2, 0), (1, 1), (0, 2) };
                Winner(this, new WinEventArgs() { Winner = v });
                return result;
            }
            return null;
        }

        /// <summary>
        /// gör så att metoden för att kolla ifall man vunnit appliceras på båda spelarna
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private (int x, int y)[] FindDiagonalWinVectorDown()
        {
            var vector = FindDiagonalWinVectorDown('X');
            if (vector != null) return vector;

            return FindDiagonalWinVectorDown('O');
        }

        /// <summary>
        /// Kollar igenom de diagonala punkterna från vänstra övre hörn för att se ifall man fått 3 irad på diagonalen
        /// </summary>
        /// <returns></returns>
        private (int x, int y)[] FindDiagonalWinVectorDown(char v)
        {
            (int x, int y)[] result = new (int, int)[3];
            if (board[0,0] == v && board[1, 1] == v && board[2, 2] == v)
            {
                result = new[] { (0, 0),(1,1),(2,2)};
                Winner(this, new WinEventArgs() { Winner = v });
                return result;
            }
            return null;
        }

        /// <summary>
        /// gör så att metoden för att kolla ifall man vunnit appliceras på båda spelarna
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private (int x, int y)[] FindHorizontalWinVector()
        {

            var vector = FindHorizontalWinVector('X');
            if (vector != null) return vector;

            return FindHorizontalWinVector('O');

        }

        /// <summary>
        /// en for loop som kollar igenom varje kolumn för att se ifall det finns 3 irad i någon av dem
        /// </summary>
        /// <returns></returns>
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
                        if (counter == 3)
                        {
                            Winner(this, new WinEventArgs() { Winner = v });
                            return result;
                        }
                    } else
                    {
                        counter = 0;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// gör så att metoden för att kolla ifall man vunnit appliceras på båda spelarna
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private (int x, int y)[] FindVerticalWinVector()
        {
            var vector = FindVerticalWinVector('X');
            if (vector != null) return vector;

            return FindVerticalWinVector('O');
        }

        /// <summary>
        /// en for loop som kollar igenom varje rad för att se ifall det finns 3 irad i någon av dem
        /// </summary>
        /// <returns></returns>
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
                        if (counter == 3)
                        {
                            Winner(this, new WinEventArgs() { Winner = v });
                            return result;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// bestämmer vart i boarden spelare har lagt en pjäs
        /// </summary>
        public void SetPosition(int x, int y, char player)
        {
            board[x, y] = player;
        }
        
    }
}
