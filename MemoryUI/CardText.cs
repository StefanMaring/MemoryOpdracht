using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MemoryLogic;

namespace MemoryUI
{
    public class CardText : CardBase
    {        
        public CardText(TextBlock icon) :base() {
            Icon = icon;            
        }
    }
}
