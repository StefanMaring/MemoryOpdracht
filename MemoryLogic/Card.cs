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
        public int Number { get; set; }
        public bool IsFlipped { get; set; }
        public bool HasBeenMatched { get; set; }

        public Card(string value, int number) { 
            Number = number + 1;
            Value = value;
            IsFlipped = false;
        }
    }
}

