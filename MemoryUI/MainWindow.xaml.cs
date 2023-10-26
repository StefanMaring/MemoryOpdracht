using MemoryData;
using MemoryLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MemoryUI
{
    public partial class MainWindow : Window
    {
        private Game game = new Game();
        private CardUI firstFlipped = null;
        private CardUI secondFlipped = null;
        private HashSet<CardUI> matchedCards = new HashSet<CardUI>();              
        private TextBlock gameMessage = new TextBlock();
        private Stopwatch stopWatch = new Stopwatch();
        private DispatcherTimer timer = new DispatcherTimer();
        private int turnAmount = 0;

        public int AmountOfCards { get; set; }
        public string PlayerName { get; set; }

        public MainWindow(int amountOfCards, string playerName)
        {             
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            game.DetermineAmountOfCards(amountOfCards);
            AmountOfCards = game.AmountOfCards;
            PlayerName = playerName;

            DrawGame(AmountOfCards);
            InitializeComponent();
            
            stopWatch.Start();
        }

        private void DrawGame(int cardAmount)
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

            gameMessage.Background = new SolidColorBrush(Colors.White);
            gameMessage.Foreground = new SolidColorBrush(Colors.Black);
            gameMessage.Margin = new Thickness(5,5,5,5);
            gameMessage.FontSize = 16;
            gameMessage.Text = $"Welkom bij Memory, {PlayerName}!";

            StackPanel panel = new StackPanel();  
            panel.Children.Add(gameMessage);
            panel.Children.Add(grid);

            AddChild(panel);
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

            CardProcessing(clickedCard);
        }

        private void CardProcessing(CardUI clickedCard)
        {
            if (firstFlipped == null)
            {
                firstFlipped = clickedCard;
                firstFlipped.IsFlipped = true;
                firstFlipped.Icon.Visibility = Visibility.Visible;

            }
            else if (secondFlipped == null)
            {
                secondFlipped = clickedCard;
                secondFlipped.IsFlipped = true;
                secondFlipped.Icon.Visibility = Visibility.Visible;

                if (firstFlipped.Icon.Text == secondFlipped.Icon.Text)
                {
                    turnAmount++;
                    gameMessage.Foreground = new SolidColorBrush(Colors.Green);
                    gameMessage.Text = "Match!";

                    matchedCards.Add(firstFlipped);
                    matchedCards.Add(secondFlipped);

                    firstFlipped = null;
                    secondFlipped = null;
                }
                else
                {
                    turnAmount++;
                    gameMessage.Foreground = new SolidColorBrush(Colors.Red);
                    gameMessage.Text = "Geen match!";

                    firstFlipped.Icon.Visibility = Visibility.Hidden;
                    firstFlipped.IsFlipped = false;
                    firstFlipped = null;

                    secondFlipped.Icon.Visibility = Visibility.Hidden;
                    secondFlipped.IsFlipped = false;
                    secondFlipped = null;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (matchedCards.Count == AmountOfCards)
            {
                timer.Stop();
                stopWatch.Stop();
              
                ScoreCalculator sc = new ScoreCalculator(AmountOfCards, (int)stopWatch.Elapsed.TotalSeconds, turnAmount);
                gameMessage.Text = $"Totaal score: {sc.CalculateScore()}";
                gameMessage.Foreground = new SolidColorBrush(Colors.Black);

                DataWriter dw = new DataWriter(PlayerName, sc.CalculateScore(), AmountOfCards);
                dw.WriteDataToJSON();
            }
        }
    }
}