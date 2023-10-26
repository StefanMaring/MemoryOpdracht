using MemoryData;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemoryUI
{
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DisplayScores();
            InitializeComponent();
        }

        public void DisplayScores()
        {
            DataReader dr = new DataReader();
            List<Data> scores = dr.ReadDataFromJSON();
            var orderedScores = (from Data data in scores
                                orderby data.Score descending
                                select data).Take(10);
           
            StackPanel scorePanel = new StackPanel();
            scorePanel.Orientation = Orientation.Vertical;
            scorePanel.HorizontalAlignment = HorizontalAlignment.Center;
            scorePanel.Margin = new Thickness(0,20,0,20);

            int index = 1;
            foreach (Data data in orderedScores)
            {
                TextBlock score = SetupScoreDisplay();
                score.Text = $"#{index} Speler: {data.PlayerName}, Score: {data.Score}, Aantal kaarten: {data.AmountOfCards}";
                scorePanel.Children.Add(score);
                index++;
            }

            AddChild(scorePanel);
        }

        public TextBlock SetupScoreDisplay()
        {
            TextBlock score = new TextBlock();
            score.Foreground = new SolidColorBrush(Colors.White);
            score.FontSize = 16;  
            score.FontWeight = FontWeights.Medium;
            score.Margin = new Thickness(5,5,5,5);

            return score;
        }
    }
}