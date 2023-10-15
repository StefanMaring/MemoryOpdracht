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

        public MainWindow(int amountOfCards)
        {
            AmountOfCards = amountOfCards;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            RenderCards(AmountOfCards);
            InitializeComponent();
        }

        public void RenderCards(int cardAmount)
        {
            int colCount = cardAmount / 2;
            int rowCount = 2;

            int windowHeightX = 800;
            int windowHeightY = 800;

            int cardHeight = windowHeightX / rowCount;
            int cardWidth = windowHeightY / colCount;

            Grid grid = new Grid();

            for (int i = 0; i < colCount; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < rowCount; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Rectangle x = new Rectangle();
                    x.Fill = new SolidColorBrush(Colors.Blue);
                    x.Height = cardHeight;
                    x.Width = cardWidth;
                    x.Margin = new Thickness(10,10,10,10);
                    x.Cursor = Cursors.Hand;
                    grid.Children.Add(x);
                    Grid.SetRow(x, i);
                    Grid.SetColumn(x, j);
                }
            }

            AddChild(grid);
        }
    }
}
