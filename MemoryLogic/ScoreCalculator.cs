using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class ScoreCalculator
    {
        private int amountOfCards;
        private int timeTillCompletion;
        private int turnAmount;

        public ScoreCalculator(int amountOfCards, int timeTillCompletion, int turnAmount)
        {
            this.amountOfCards = amountOfCards;
            this.timeTillCompletion = timeTillCompletion;
            this.turnAmount = turnAmount;
        }

        public double CalculateScore()
        {
            double score = (Math.Pow(amountOfCards, 2) / (timeTillCompletion * turnAmount) * 1000);
            double scoreCeil = Math.Ceiling(score);
            return scoreCeil;
        }
    }
}
