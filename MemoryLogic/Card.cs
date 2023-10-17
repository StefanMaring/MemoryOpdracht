using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class Card
    {
        public string Value { get; set; }
        public bool IsFlipped { get; set; }

        public Card(string value) { 
            Value = value;
            IsFlipped = false;
        }
    }
}

