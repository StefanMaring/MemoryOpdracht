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
                try
                {
                    Console.WriteLine("Geef het getal van de eerste kaart die je wilt draaien:");
                    firstFlippedNumber = int.Parse(Console.ReadLine());

                    if (firstFlippedCard == null)
                    {
                        firstFlippedCard = Game.gameCards[firstFlippedNumber - 1];
                        firstFlippedCard.IsFlipped = true;
                        Console.WriteLine($"waarde: {firstFlippedCard.Value}");
                    }

                    Console.WriteLine("Geef het getal van de tweede kaart die je wilt draaien:");
                    secondFlippedNumber = int.Parse(Console.ReadLine());

                    if (secondFlippedCard == null)
                    {
                        secondFlippedCard = Game.gameCards[secondFlippedNumber - 1];
                        secondFlippedCard.IsFlipped = true;
                        Console.WriteLine($"waarde: {secondFlippedCard.Value}");
                    }

                    if (firstFlippedCard.Equals(secondFlippedCard))
                    {
                        Console.WriteLine("Deze kaart is al omgedraaid!");
                        continue;
                    } else
                    {
                        if (firstFlippedCard.Value == secondFlippedCard.Value)
                        {
                            turnAmount++;
                            Console.WriteLine("Match!");
                            firstFlippedCard = null;
                            secondFlippedCard = null;
                        } else
                        {
                            turnAmount++;
                            Console.WriteLine("Geen match!");
                            firstFlippedCard.IsFlipped = false;
                            firstFlippedCard = null;

                            secondFlippedCard.IsFlipped = false;
                            secondFlippedCard = null;
                        }
                    }                   
                } catch(FormatException)
                {
                    Console.WriteLine("Alleen getallen mogen worden ingevoerd!");
                }
            }
        }        
    }
}
