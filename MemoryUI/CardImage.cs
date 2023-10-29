using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MemoryUI
{
    public class CardImage : CardBase
    {
        public string ImagePath { get; set; }

        public CardImage(string imagePath, TextBlock icon) :base()
        {
            ImagePath = imagePath;
            Icon = icon;
            Background = new ImageBrush(SetImage(ImagePath));
        }

        private BitmapImage SetImage(string imagePath)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(imagePath, UriKind.Relative);
            image.EndInit();
            return image;
        }
    }
}
