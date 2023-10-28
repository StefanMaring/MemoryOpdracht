using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MemoryUI
{
    public partial class StartWindow : Window
    {
        private const string imageFilePath = "cardImages/";

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
                    MessageBox.Text = "Naam mag niet leeg zijn!";
                    return;
                }

                if(cardAmount < 8) {
                    amountOfCards.Text = "";
                    MessageBox.Text = "Minimaal 8 kaarten!";
                    return;
                }

                if(cardAmount > 20)
                {
                    amountOfCards.Text = "";
                    MessageBox.Text = "Maximaal 20 kaarten!";
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
                    amountOfCards.Text = "";
                    MessageBox.Text = "Alleen even getallen!";
                }
            } catch (FormatException)
            {
                amountOfCards.Text = "";
                MessageBox.Text = "Alleen getallen!";
            }
        }

        private void UploadImagesEvent(object sender, RoutedEventArgs e)
        {
            List<string> images = new List<string>();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() == true)
            {
                foreach (string imageFile in fileDialog.FileNames) {
                    images.Add(imageFile);
                }

                SaveImagesToDirectory(images, imageFilePath);
            }
        }

        private void SaveImagesToDirectory(List<string> images, string directory)
        {
            foreach (string imageFile in images)
            {
                string destinationPath = System.IO.Path.Combine(directory, System.IO.Path.GetFileName(imageFile));
                File.Copy(imageFile, destinationPath, true);
            }
            MessageBox.Text = "Foto's succesvol geüpload!";
        }
    }
}