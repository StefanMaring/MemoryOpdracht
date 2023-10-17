using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class Game
    {
        private int amountOfCards;
        public int AmountOfCards { get; private set; }

        private List<Card> gameCards = new List<Card>();

        public Game(int amountOfCards) {
            CreateCards(DetermineAmountOfCards(amountOfCards));
        }

        public int DetermineAmountOfCards(int amountOfCards)
        {
            if (amountOfCards % 2 != 0)
            {
                Console.WriteLine("Alleen even getallen zijn toegestaan!");
            }

            if (amountOfCards < 8)
            {
                Console.WriteLine("Aantal kaarten moet minimaal 8 zijn!");
            }
            
            if(amountOfCards > 20)
            {
                Console.WriteLine("Aantal kaarten mag maximaal 20 zijn!");
            }           

            switch (amountOfCards)
            {
                case 8:
                    return 8;
                case 10:
                    return 10;
                case 12:
                    return 12;
                case 14:
                    return 14;
                case 16:
                    return 16;
                case 18:
                    return 18;
                case 20:
                    return 20;
            }

            return 0;
        }

        private string[] CreateCardValues(int amountOfCards)
        {
            switch (amountOfCards)
            {
                case 8:
                    string[] valuesEight = {"@","@","$","$","&","&","*","*"};
                    return valuesEight;
                case 10:
                    string[] valuesTen = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X"};
                    return valuesTen;
                case 12:
                    string[] valuesTwelve = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X", "#", "#" };
                    return valuesTwelve;
                case 14:
                    string[] valuesFourteen = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X", "#", "#", "^", "^" };
                    return valuesFourteen;
                case 16:
                    string[] valuesSixteen = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X", "#", "#", "^", "^", "%", "%" };
                    return valuesSixteen;
                case 18:
                    string[] valuesEighteen = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X", "#", "#", "^", "^", "%", "%", "!", "!" };
                    return valuesEighteen;
                case 20:
                    string[] valuesTwenty = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X", "#", "#", "^", "^", "%", "%", "!", "!", "+", "+" };
                    return valuesTwenty;
            }

            return null;
        }

        public void CreateCards(int amountOfCards) {
            string[] cardValues = CreateCardValues(amountOfCards);

            for(int i = 0; i < amountOfCards; i++)
            {
                gameCards.Add(new Card(cardValues[i]));
            }
        }
    }
}
