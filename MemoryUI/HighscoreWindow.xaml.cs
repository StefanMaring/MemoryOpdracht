using MemoryData;
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
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

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
            var orderedScores = from Data data in scores
                                orderby data.Score descending
                                select data;
           
            StackPanel scorePanel = new StackPanel();
            scorePanel.Orientation = Orientation.Vertical;
            scorePanel.HorizontalAlignment = HorizontalAlignment.Center;
            scorePanel.Margin = new Thickness(0,20,0,20);

            foreach (Data data in orderedScores)
            {
                TextBlock score = SetupScoreDisplay();
                score.Text = $"Speler: {data.PlayerName}, Score: {data.Score}, Aantal kaarten: {data.AmountOfCards}";
                scorePanel.Children.Add(score);
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