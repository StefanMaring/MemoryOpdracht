using MemoryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
        private Game game = new Game();
        private CardUI firstFlipped = null;
        private CardUI secondFlipped = null;
        private int turnAmount = 0;
        private HashSet<CardUI> matchedCards = new HashSet<CardUI>();
        public int AmountOfCards { get; set; }

        public MainWindow(int amountOfCards)
        {             
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            game.DetermineAmountOfCards(amountOfCards);
            AmountOfCards = game.AmountOfCards;

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

            string[] cardValues = game.ShuffleCardValues(game.CreateCardValues(cardAmount)); //shuffled array of card values
            int valueIndex = 0;

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
                    CardUI card = new CardUI(CreateTextBlock());                   
                    card.Height = cardHeight;
                    card.Width = cardWidth;
                    card.Background = new SolidColorBrush(Colors.Blue);                
                    card.Margin = new Thickness(5,5,5,5);
                    card.Cursor = Cursors.Hand;                   
                    card.Name = $"card_{row}_{col}";
                    card.MouseLeftButtonDown += CardClicked; //event
                    card.SetCardIcon(cardValues[valueIndex]); //assign value to card
                    valueIndex++;

                    grid.Children.Add(card);
                    Grid.SetRow(card, row);
                    Grid.SetColumn(card, col); 
                }
            }

            AddChild(grid);
        }       

        private TextBlock CreateTextBlock()
        {
            TextBlock icon = new TextBlock();
            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.Foreground = new SolidColorBrush(Colors.White);
            icon.FontSize = 42;
            icon.Visibility = Visibility.Hidden;
            
            return icon;
        }

        private void CardClicked(object sender, MouseButtonEventArgs e)
        {
            CardUI clickedCard = e.Source as CardUI;

            if (clickedCard == null || clickedCard.IsFlipped)
            {
                return;
            }

            if(matchedCards.Count == amountOfCards)
            {
                //Score calc and pop-up with score
            }

            if(firstFlipped == null)
            {
                firstFlipped = clickedCard;
                firstFlipped.IsFlipped = true;
                firstFlipped.Icon.Visibility = Visibility.Visible;

            } else if(secondFlipped == null)
            {
                secondFlipped = clickedCard;
                secondFlipped.IsFlipped = true;
                secondFlipped.Icon.Visibility = Visibility.Visible;

                if(firstFlipped.Icon.Text == secondFlipped.Icon.Text)
                {
                    turnAmount++;

                    matchedCards.Add(firstFlipped);
                    matchedCards.Add(secondFlipped);

                    firstFlipped = null;
                    secondFlipped = null;
                } else
                {
                    turnAmount++;

                    firstFlipped.Icon.Visibility = Visibility.Hidden;
                    firstFlipped.IsFlipped = false;
                    firstFlipped = null;

                    secondFlipped.Icon.Visibility = Visibility.Hidden;
                    secondFlipped.IsFlipped = false;
                    secondFlipped = null;
                }
            }
        } 
    }
}