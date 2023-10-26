using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryData
{
    public class Data
    {
        private string playerName;
        private double score;
        private int amountOfCards;

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public double Score { get { return score; } set { score = value; } }
        public int AmountOfCards { get { return amountOfCards; } set { amountOfCards = value; } }
    }
}
