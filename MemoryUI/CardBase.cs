using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MemoryUI
{
    public abstract class CardBase : Border
    {
        public bool IsFlipped { get; set; }
        public TextBlock Icon { get; set; }

        public void SetCardIcon(string cardValue)
        {
            Icon.Text = cardValue;
            Child = Icon;
        }
    }
}
