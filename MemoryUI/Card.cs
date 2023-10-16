using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MemoryUI
{
    public class Card : Border
    {
        public bool IsFlipped { get; set; }
        public TextBlock Value { get; set; }

        public Card(TextBlock icon) {
            Value = icon;
            Child = icon;
        }
    }
}
