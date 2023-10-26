using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MemoryUI
{
    public class ButtonUI : Button
    {
        public ButtonUI CreateButton(string name, string content, HorizontalAlignment alignment)
        {
            ButtonUI button = new ButtonUI();
            button.Background = new SolidColorBrush(Colors.Blue);
            button.Foreground = new SolidColorBrush(Colors.White);
            button.FontSize = 16;
            button.FontWeight = FontWeights.Bold;
            button.Cursor = Cursors.Hand;
            button.Margin = new Thickness(0, 5, 5, 5);
            button.HorizontalAlignment = alignment;
            button.Name = name;
            button.Content = content;
            return button;
        }
    }
}
