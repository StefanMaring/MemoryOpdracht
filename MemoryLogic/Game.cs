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
        private List<Card> gameCards = new List<Card>();
        private int AmountOfCards;

        public Game(int amountOfCards) {
            if(DetermineAmountOfCards(amountOfCards)) {
                CreateCards(AmountOfCards);
                RunGame();
            }            
        }

        private bool DetermineAmountOfCards(int amountOfCards)
        {
            if (amountOfCards < 8)
            {
                Console.WriteLine("Aantal kaarten moet minimaal 8 zijn!");
                return false;
            }

            if (amountOfCards > 20)
            {
                Console.WriteLine("Aantal kaarten mag maximaal 20 zijn!");
                return false;
            }

            if (amountOfCards % 2 != 0)
            {
                amountOfCards = amountOfCards + 1;
            }                                

            switch (amountOfCards)
            {
                case 8:
                    AmountOfCards = 8;
                    return true;
                case 10:
                    AmountOfCards = 10;
                    return true;
                case 12:
                    AmountOfCards = 12;
                    return true;
                case 14:
                    AmountOfCards = 14;
                    return true;
                case 16:
                    AmountOfCards = 16;
                    return true;
                case 18:
                    AmountOfCards = 18;
                    return true;
                case 20:
                    AmountOfCards = 20;
                    return true;
                default:
                    AmountOfCards = 10;
                    return true;
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
                gameCards.Add(new Card(cardValues[i],i));
            }
        }

        private void RunGame()
        {
            new GameController(gameCards);
        }
    }
}