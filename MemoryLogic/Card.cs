using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class Card
    {
        private string value;
        private bool isFlipped;

        public string Value { get { return value; } set { value = Value; } }
        public bool IsFlipped { get; set; }

        public Card(string value) { 
            Value = value;
            isFlipped = false;

        }
    }
}

