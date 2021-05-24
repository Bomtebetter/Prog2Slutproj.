using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        private int scoreX = 0;
        private int scoreO = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_NewGame(object sender, RoutedEventArgs e)
        {
            Gameboard.Game.NewGame();
        }
    }
}
