using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class GameController
    {
        private Card firstFlippedCard = null;
        private Card secondFlippedCard = null;
        private bool gameRunning = true;
        private int turnAmount = 0;
        private List<Card> cards;
        private HashSet<Card> matchedCards = new HashSet<Card>();
        private Stopwatch stopWatch = new Stopwatch();

        public GameController(List<Card> cards)
        {
            this.cards = cards;
            GameControls();
        }

        private void GameControls()
        {
            while (gameRunning)
            {
                //stopWatch.Start();

                if (matchedCards.Count == cards.Count)
                {
                    EndOfGame();
                    break;
                }

                try
                {
                    Console.WriteLine("Geef het getal van de kaart die je wilt draaien:");
                    int pos = int.Parse(Console.ReadLine());

                    if (pos > cards.Count)
                    {
                        Console.WriteLine($"De invoer moet kleiner zijn dan {cards.Count}!");
                        continue;
                    }

                    Card enteredCard = cards[pos - 1];

                    if (matchedCards.Contains(enteredCard))
                    {
                        Console.WriteLine("De kaart is al gematched!");
                        continue;
                    }

                    if (enteredCard.IsFlipped)
                    {
                        Console.WriteLine("De kaart is al omgedraaid!");
                        continue;
                    }                    

                    enteredCard.IsFlipped = true;                   

                    if (firstFlippedCard == null) //Checking if cards match or not
                    {
                        firstFlippedCard = enteredCard;
                        Console.WriteLine($"Waarde kaart: {firstFlippedCard.Value}");
                    }
                    else if(secondFlippedCard == null)
                    {      
                        secondFlippedCard = enteredCard;
                        Console.WriteLine($"Waarde kaart: {secondFlippedCard.Value}");

                        if (firstFlippedCard.Value == secondFlippedCard.Value)
                        {
                            turnAmount++;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Match!");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            matchedCards.Add(firstFlippedCard);
                            matchedCards.Add(secondFlippedCard);

                            firstFlippedCard = null;
                            secondFlippedCard = null;
                        }
                        else
                        {
                            turnAmount++;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Geen match!");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            firstFlippedCard.IsFlipped = false;                            
                            secondFlippedCard.IsFlipped = false;

                            firstFlippedCard = null;
                            secondFlippedCard = null;
                        }
                    }
                } catch(FormatException)
                {
                    Console.WriteLine("Invoer mag alleen uit getallen bestaan!");
                }                                
            }
        }  
        
        private void EndOfGame()
        {
            gameRunning = false;
            stopWatch.Stop();
            int elapsedTime = int.Parse(stopWatch.Elapsed.ToString());

            ScoreCalculator sc = new ScoreCalculator(cards.Count, elapsedTime, turnAmount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Je hebt succesvol alle kaarten gematched!");
            Console.WriteLine($"Score: {sc.CalculateScore()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
