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
        private bool gameRunning = true;
        private int turnAmount = 0;

        public Game Game { get; }

        private List<Card> matchedCards = new List<Card>();

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
                    Console.WriteLine("Geef het getal van de kaart die je wilt draaien:");
                    int pos = int.Parse(Console.ReadLine());

                    if (pos > Game.gameCards.Count)
                    {
                        Console.WriteLine($"De invoer moet kleiner zijn dan {Game.gameCards.Count}");
                        continue;
                    }

                    Card enteredCard = Game.gameCards[pos - 1];

                    if (matchedCards.Contains(enteredCard))
                    {
                        Console.WriteLine("De kaart is al gematched of omgedraaid!");
                        continue;
                    }

                    if (enteredCard == null || enteredCard.IsFlipped)
                    {
                        continue;
                    }                    

                    enteredCard.IsFlipped = true;

                    if (firstFlippedCard == null)
                    {
                        firstFlippedCard = enteredCard;
                        Console.WriteLine($"waarde: {firstFlippedCard.Value}");
                    }
                    else
                    {                       
                        Console.WriteLine($"waarde: {enteredCard.Value}");

                        if (firstFlippedCard.Value == enteredCard.Value)
                        {
                            turnAmount++;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Match!");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            matchedCards.Add(firstFlippedCard);
                            matchedCards.Add(enteredCard);
                            firstFlippedCard = null;
                        }
                        else
                        {
                            turnAmount++;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Geen match!");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            firstFlippedCard.IsFlipped = false;                            
                            enteredCard.IsFlipped = false;
                            firstFlippedCard = null;
                        }
                    }
                } catch(FormatException)
                {
                    Console.WriteLine("Invoer mag alleen uit getallen bestaan!");
                }                                
            }
        }        
    }
}
