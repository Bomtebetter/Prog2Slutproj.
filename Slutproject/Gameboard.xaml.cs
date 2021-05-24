using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Slutproject
{
    /// <summary>
    /// Interaction logic for Gameboard.xaml
    /// </summary>
    public partial class Gameboard : UserControl
    {
        private int boardSize = 3;
        private static  GameEngine ge;
        private char currentPlayer = 'X';

        public static GameEngine Game { get => ge; set => ge = value; }

        public Gameboard()
        {
            InitializeComponent();
            Game = new GameEngine(boardSize);
            UpdateBoard();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            var clickedPosition = button.Name.Substring(1);

            Game.SetPosition(int.Parse(clickedPosition.Substring(0,1)), int.Parse(clickedPosition.Substring(1,1)), currentPlayer);

            var winVector = Game.GetWinVector(clickedPosition);

            if (winVector != null)
            {
                SetWinningRow(winVector);
            }

            UpdateBoard();
            PlayerChange();

        }

        private void UpdateBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    ((Button)this.FindName("b" + i + j)).Content = Game.Board[i,j];
                }
            }

        }

        private void SetWinningRow((int x, int y)[] winVector)
        {
            foreach (var item in winVector)
            {
                ((Button)this.FindName("b" + item.x + item.y)).Background = Brushes.Green;

            }
        }

        private void PlayerChange()
        {
            if (currentPlayer.Equals('X'))
            {
                currentPlayer = 'O';
            }
            else if (currentPlayer.Equals('O'))
            {
                currentPlayer = 'X';
            }
        }
    }
}
