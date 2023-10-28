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

namespace MemoryUI
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void StartGameEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                int cardAmount = int.Parse(amountOfCards.Text);
                string playerName = playerField.Text;

                if(playerName == "" || playerName == null)
                {
                    playerField.Text = "Naam mag niet leeg zijn!";
                    return;
                }

                if(cardAmount < 8) { 
                    amountOfCards.Text = "Minimaal 8 kaarten!";
                    return;
                }

                if(cardAmount > 20)
                {
                    amountOfCards.Text = "Maximaal 20 kaarten!";
                    return;
                }

                if (cardAmount % 2 == 0)
                {
                    if(withImagesChck.IsChecked == false)
                    {
                        MainWindow mw = new MainWindow(cardAmount, playerName, false);

                        mw.Show();
                        this.Close();
                    } else
                    {
                        MainWindow mwi = new MainWindow(cardAmount, playerName, true);

                        mwi.Show();
                        this.Close();
                    }                    
                }
                else
                {
                    amountOfCards.Text = "Alleen even getallen!";
                }
            } catch (FormatException)
            {
                amountOfCards.Text = "Alleen getallen!";
            }
        }

        private void UploadImagesEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
