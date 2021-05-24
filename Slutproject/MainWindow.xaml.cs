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
        public static readonly DependencyProperty ScoreXProperty = DependencyProperty.Register("ScoreX", typeof(int), typeof(MainWindow));
        /// <summary>
        /// För att texten i gui ska binda så är det en dependencyprop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int ScoreX  
        {
            get { return (int)GetValue(ScoreXProperty); }
            set { SetValue(ScoreXProperty, value); }
        }
        

        public static readonly DependencyProperty ScoreOProperty = DependencyProperty.Register("ScoreO", typeof(int), typeof(MainWindow));

        /// <summary>
        /// För att texten i gui ska binda så är det en dependencyprop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int ScoreO
        {
            get { return (int)GetValue(ScoreOProperty); }
            set { SetValue(ScoreOProperty, value); }
        }
        

        public MainWindow()
        {
            InitializeComponent();
            var gameboard = this.FindName("gameboard") as Gameboard;

            gameboard.Game.Winner += Game_Winner;
        }

        /// <summary>
        /// utdelar poäng till den som får 3 i rad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Winner(object sender, WinEventArgs e)
        {
            if (e.Winner.Equals('X')) ScoreX++;
            else ScoreO++;
        }

        /// <summary>
        /// Dödar applicationen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        ///  tillkallar metoder för att rensabrädet så man kan köra igen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_NewGame(object sender, RoutedEventArgs e)
        {
            var gameboard = this.FindName("gameboard") as Gameboard;
            gameboard.Game.NewGame();
            gameboard.UpdateBoard();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScoreO = 0;
            ScoreX = 0;
        }
        
    }
}
