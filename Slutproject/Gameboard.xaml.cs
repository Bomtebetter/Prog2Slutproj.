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

        public GameEngine Game { get; }

        /// <summary>
        /// Initierar att Spelare X börjar och sedan startar spelet och kör ett refresh på spelbrädet
        /// </summary>
        public Gameboard()
        {
            CurrentPlayer = 'X';
            InitializeComponent();
            Game = new GameEngine(boardSize);
            Game.NewGame();
            UpdateBoard();
        }
        

        public static readonly DependencyProperty CurrentPlayerProperty = DependencyProperty.Register("CurrentPlayer", typeof(char), typeof(Gameboard));

        /// <summary>
        /// För att texten i gui ska binda så är det en dependencyprop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public char CurrentPlayer
        {
            get { return (char)GetValue(CurrentPlayerProperty); }
            set { SetValue(CurrentPlayerProperty, value); }
        }

        /// <summary>
        /// börjar med att kolla ifall GameEnabled är true/false ifall sann låter en spela
        /// kollar om knappens innehåll är '-' isåfall registrerar den det som ett "spelmove"
        /// ifall '-' byt ut knappens innehåll till X/O beroende på vems tur
        /// jämför sedan ens klickade position för att se ifall man har lagt tre irad ifall ja = vinn 
        /// ifall nej = byt spelare och förtsätt att spela
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Game.GameEnabled) return;

            var button = ((Button)sender);
            var clickedPosition = button.Name.Substring(1);

            if (!button.Content.Equals('-')) return;

            Game.SetPosition(int.Parse(clickedPosition.Substring(0,1)), int.Parse(clickedPosition.Substring(1,1)), CurrentPlayer);

            UpdateBoard();

            var winVector = Game.GetWinVector(clickedPosition);

            if (winVector != null)
            {
                Game.GameEnabled = false;
                SetWinningRow(winVector);
            }
            PlayerChange();
        }

        /// <summary>
        /// Lägger en refresh på gameboardets innehål för användarvyn
        /// </summary>
        /// <param name="winVector"></param>
        public void UpdateBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    ((Button)this.FindName("b" + i + j)).Content = Game.Board[i,j];
                    ((Button)this.FindName("b" + i + j)).Background = Brushes.LightGray;
                }
            }
        }

        /// <summary>
        /// Målar bakgrunden grön på de knappar som gör 3 i rad
        /// </summary>
        private void SetWinningRow((int x, int y)[] winVector)
        {
            foreach (var item in winVector)
            {
                ((Button)this.FindName("b" + item.x + item.y)).Background = Brushes.Green;
            }
        }

        /// <summary>
        /// Gör så att man den växelvis byter spelare
        /// </summary>
        private void PlayerChange()
        {
            if (CurrentPlayer.Equals('X'))
            {
                CurrentPlayer = 'O';
            }
            else if (CurrentPlayer.Equals('O'))
            {
                CurrentPlayer = 'X';
            }
        }
        
    }
}
