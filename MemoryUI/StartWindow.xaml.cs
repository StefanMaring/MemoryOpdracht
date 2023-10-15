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

                if (cardAmount % 2 == 0)
                {
                    MainWindow mw = new MainWindow(cardAmount);

                    mw.Show();
                    this.Close();
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
    }
}
