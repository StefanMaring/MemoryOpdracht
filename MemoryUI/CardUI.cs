using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MemoryLogic;

namespace MemoryUI
{
    public class CardUI : Border 
    {
        public bool IsFlipped { get; set; }
        public TextBlock Value { get; set; }

        public CardUI(TextBlock icon) {
            Value = icon;
            Child = icon;
        }
    }
}
