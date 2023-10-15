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

        private List<string> icons = new List<string>()
        {
            "#", "#", "$", "$", "X", "X", "&", "&",
            "@", "@", "!", "!", "%", "%", "*", "*"
        };

        public MainWindow(int amountOfCards)
        {
            AmountOfCards = amountOfCards;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            RenderCards(AmountOfCards);
            InitializeComponent();
        }

        private void RenderCards(int cardAmount)
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

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Border card = new Border();                    
                    card.Height = cardHeight;
                    card.Width = cardWidth;
                    card.Background = new SolidColorBrush(Colors.Blue);
                    card.Margin = new Thickness(10,10,10,10);
                    card.Cursor = Cursors.Hand;
                    card.Child = AssignIconToCard();
                    card.Name = $"card_{row}_{col}";
                    card.MouseLeftButtonDown += CardClicked; //event

                    grid.Children.Add(card);
                    Grid.SetRow(card, row);
                    Grid.SetColumn(card, col); 
                }
            }

            AddChild(grid);
        }       

        private TextBlock AssignIconToCard()
        {
            TextBlock icon = new TextBlock();
            Random random = new Random();

            int iconNumber = random.Next(icons.Count);

            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.Foreground = new SolidColorBrush(Colors.White);
            icon.FontSize = 42;
            icon.Visibility = Visibility.Hidden;
            icon.Text = icons[iconNumber];

            icons.RemoveAt(iconNumber);

            return icon;
        }

        private void CardClicked(object sender, MouseButtonEventArgs e)
        {
            Border wasClicked = e.Source as Border;
            string name = wasClicked.Name;

            var text = wasClicked.Child as TextBlock;
            text.Visibility = Visibility.Visible;
        }
    }
}
