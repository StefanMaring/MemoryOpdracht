using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class GameController
    {
        private Card firstFlippedCard = null;
        private Card secondFlippedCard = null;

        private int firstFlippedNumber;
        private int secondFlippedNumber;

        private bool gameRunning = true;
        private int turnAmount = 0;

        public Game Game { get; }

        public GameController(Game game)
        {
            Game = game;
            GameControl();
        }

        private void GameControl()
        {
            while (gameRunning)
            {
                //try catch
                Console.WriteLine("Geef het getal van de kaart die je wilt draaien:");
                firstFlippedNumber = int.Parse(Console.ReadLine());
                Card enteredCard = Game.gameCards[firstFlippedNumber - 1];

                if (enteredCard == null || enteredCard.IsFlipped)
                {
                    return;
                }             

                enteredCard.IsFlipped = true;
                
                if (firstFlippedCard == null)
                {
                    firstFlippedCard = enteredCard;
                    Console.WriteLine($"waarde: {firstFlippedCard.Value}");
                } else
                {
                    Console.WriteLine($"waarde: {enteredCard.Value}");

                    if (firstFlippedCard.Value == enteredCard.Value)
                    {
                        Console.WriteLine("Match!");
                        firstFlippedCard = null;
                    }
                    else
                    {
                        Console.WriteLine("Geen match!");
                        firstFlippedCard.IsFlipped = false;

                        enteredCard.IsFlipped = false;
                        firstFlippedCard = null;
                    }
                }                 
            }
        }        
    }
}
