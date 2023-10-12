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

namespace MemoryUI
{
    public partial class MainWindow : Window
    {
        private int amountOfCards;
        public int AmountOfCards { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(int amountOfCards)
        {
            AmountOfCards = amountOfCards;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            RenderCards();

            InitializeComponent();
        }

        public void RenderCards()
        {
            int amount = AmountOfCards;
            int colCount = amount / 2;
            int rowCount = amount / 2;

            int height = 50;
            int width = 50;

            Grid grid = new Grid();

            for(int i = 0; i < colCount; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int i = 0; i < rowCount; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            foreach (var g in grid.RowDefinitions)
            {
                g.Height = new GridLength(height);
            }

            foreach (var g in grid.ColumnDefinitions)
            {
                g.Width = new GridLength(width);
            }

            for(int i = 0; i < rowCount;)
            {
                for(int j = 0; j < colCount; j++)
                {
                    int idx = grid.Children.Add(new Rectangle());
                    Rectangle x = grid.Children[idx] as Rectangle;

                    x.Fill = new SolidColorBrush(Colors.Blue);
                    x.SetValue(Grid.RowProperty, i);
                    x.SetValue(Grid.ColumnProperty, j);
                }
                i++;
            }

            AddChild(grid);
        }
    }
}
