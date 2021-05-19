using System;
using System.Collections;
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
            const int BoardSize = 5;

            Board = new List<List<GridItem>>();
            for (int i = 0; i < BoardSize; i++)
            {
                var list = new List<GridItem>();
                for (int j = 0; j < BoardSize; j++)
                {
                    list.Add(new GridItem());
                }
                Board.Add(list);
            }
            DataContext = Board;
            //foreach (var list in Board)
            //{
            //   Grid.RowDefinitions.Add(new RowDefinition());
            //   foreach (var item in list)
            //    {
            //        Grid.ColumnDefinitions.Add(new ColumnDefinition());
            //        Grid.Children.Add(new TextBlock() { Text = item.ToString() });
            //    }
            //}
        }

        public List<List<GridItem>> Board { get; set; }

        public class GridItem
        {
            public Status Status = Status.Clear;

            public string xxx { get { return Status.ToString(); } }
        }

        public enum Status { Clear = 0, X = 1, Y = 2 }
    }
}
