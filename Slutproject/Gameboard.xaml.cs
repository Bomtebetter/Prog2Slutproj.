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
        public Gameboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedPosition = ((Button)sender).Name.Substring(1);

            TogglePosition(clickedPosition);

            var winVector = GetWinVector(clickedPosition);

            if (winVector != null)
            {
                SetWinningRow(winVector);
            }

        }

        private void SetWinningRow(object winVector)
        {
            throw new NotImplementedException();
        }

        private object GetWinVector(object clickedPosition)
        {
            throw new NotImplementedException();
        }

        private void TogglePosition(object clickedPosition)
        {
            throw new NotImplementedException();
        }

        private void CheckThreeInRow()
        {

        }
    }
}
