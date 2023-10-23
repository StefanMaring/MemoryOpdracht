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
        public TextBlock Icon { get; set; }

        public CardUI(TextBlock icon) {
            Icon = icon;            
        }

        public void SetCardIcon(string cardValue)
        {
            Icon.Text = cardValue;
            Child = Icon;
        }
    }
}
