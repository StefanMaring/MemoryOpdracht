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

        public List<Card> gameCards = new List<Card>();

        public Game(int amountOfCards) {
            DetermineAmountOfCards(amountOfCards);
            CreateCards(AmountOfCards);
        }

        public void DetermineAmountOfCards(int amountOfCards)
        {
            if (amountOfCards % 2 != 0)
            {
                Console.WriteLine("Alleen even getallen zijn toegestaan!");
                return;
            }

            if (amountOfCards < 8)
            {
                Console.WriteLine("Aantal kaarten moet minimaal 8 zijn!");
                return;
            }
            
            if(amountOfCards > 20)
            {
                Console.WriteLine("Aantal kaarten mag maximaal 20 zijn!");
                return;
            }           

            switch (amountOfCards)
            {
                case 8:
                    AmountOfCards = 8;
                    break;
                case 10:
                    AmountOfCards = 10;
                    break;
                case 12:
                    AmountOfCards = 12;
                    break;
                case 14:
                    AmountOfCards = 14;
                    break;
                case 16:
                    AmountOfCards = 16;
                    break;
                case 18:
                    AmountOfCards = 18;
                    break;
                case 20:
                    AmountOfCards = 20;
                    break;
                default:
                    AmountOfCards = 10;
                    break;
            }
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
                default:
                    string[] defaultValues = { "@", "@", "$", "$", "&", "&", "*", "*", "X", "X" };
                    return defaultValues;
            }
        }  
        
        private string[] ShuffleCardValues(string[] values)
        {
            Random r = new Random();
            string[] shuffledValues = values.OrderBy(x => r.Next()).ToArray();
            return shuffledValues;
        }

        private void CreateCards(int amountOfCards) {
            string[] cardValues = ShuffleCardValues(CreateCardValues(amountOfCards));

            for(int i = 0; i < amountOfCards; i++)
            {
                gameCards.Add(new Card(cardValues[i]));
            }
        }

        public void PrintCards() //test function
        {
            foreach (Card item in gameCards)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}