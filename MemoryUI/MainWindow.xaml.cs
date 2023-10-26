﻿using MemoryData;
using MemoryLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
        private ButtonUI resetGameBtn;
        private ButtonUI scoreTabBtn;
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

            int windowHeightX = 700;
            int windowWidthY = 900;

            int cardHeight = windowHeightX / rowCount;
            int cardWidth = windowWidthY / colCount;

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
            gameMessage.HorizontalAlignment = HorizontalAlignment.Left;
            gameMessage.Margin = new Thickness(5,5,5,5);
            gameMessage.FontSize = 16;
            gameMessage.Text = $"Welkom bij Memory, {PlayerName}!";

            ButtonUI btn1 = new ButtonUI();
            resetGameBtn = btn1.CreateButton("ResetGameButton", "Reset", HorizontalAlignment.Left);
            resetGameBtn.Click += ResetGameBtn_Click;

            ButtonUI btn2 = new ButtonUI();
            scoreTabBtn = btn2.CreateButton("ScoreTabButton", "Highscores", HorizontalAlignment.Right);
            scoreTabBtn.Click += ScoreTabBtn_Click;
                         
            DockPanel btnPanel = new DockPanel();
            btnPanel.HorizontalAlignment = HorizontalAlignment.Right;       
            btnPanel.Children.Add(resetGameBtn); 
            btnPanel.Children.Add(scoreTabBtn);

            DockPanel topPanel = new DockPanel();
            topPanel.Children.Add(gameMessage);
            topPanel.Children.Add(btnPanel);

            StackPanel panel = new StackPanel();
            panel.Children.Add(topPanel);
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

        private void Timer_Tick(object sender, EventArgs e) //Event that checks if cards are all matched
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

        private void ScoreTabBtn_Click(object sender, RoutedEventArgs e)
        {
            HighscoreWindow hw = new HighscoreWindow();
            hw.Show();
        }

        private void ResetGameBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow sw = new StartWindow();
            sw.Show();
            this.Close();
        }
    }
}