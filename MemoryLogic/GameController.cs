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

        public GameController(List<Card> cards)
        {
            this.cards = cards;
            GameControls();
        }

        private void GameControls()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            while (gameRunning)
            {             
                if (matchedCards.Count == cards.Count)
                {
                    EndOfGame(stopWatch.Elapsed);
                    break;
                }

                try
                {
                    Console.WriteLine("Draai kaart:");
                    int pos = int.Parse(Console.ReadLine());

                    try
                    {
                        Card enteredCard = cards[pos - 1];

                        if (matchedCards.Contains(enteredCard))
                        {
                            Console.WriteLine("De kaart is al gematched!");
                            DisplayMatched(); //allows user to see which cards already have been turned
                            continue;
                        }

                        if (enteredCard.IsFlipped)
                        {
                            Console.WriteLine("De kaart is al omgedraaid!");
                            continue;
                        }

                        if (firstFlippedCard == null) //set first card
                        {
                            firstFlippedCard = enteredCard;
                            firstFlippedCard.IsFlipped = true;

                            Console.WriteLine($"Waarde kaart: {firstFlippedCard.Value}");
                        }
                        else if (secondFlippedCard == null) //set second card
                        {
                            secondFlippedCard = enteredCard;
                            secondFlippedCard.IsFlipped = true;

                            Console.WriteLine($"Waarde kaart: {secondFlippedCard.Value}");
                            CheckIfCardsMatch(firstFlippedCard, secondFlippedCard); //check to see if cards match
                        }
                    }
                    catch (ArgumentOutOfRangeException) {
                        Console.WriteLine($"Invoer mag niet groter zijn dan {cards.Count}");
                    }
                } 
                catch(FormatException)
                {
                    Console.WriteLine("Invoer mag alleen uit getallen bestaan!");
                }                                
            }
            stopWatch.Stop();
        }
        
        private void CheckIfCardsMatch(Card card, Card card2)
        {
            if (card.Value == card2.Value)
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
        
        private void EndOfGame(TimeSpan timeSpan)
        {
            gameRunning = false;            
            ScoreCalculator sc = new ScoreCalculator(cards.Count, (int)timeSpan.TotalSeconds, turnAmount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Je hebt succesvol alle kaarten gematched!");
            Console.WriteLine($"Score: {sc.CalculateScore()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DisplayMatched()
        {
            if(matchedCards.Count > 0)
            {
                Console.WriteLine("Gematchde kaarten: ");
                List<Card> orderedCards = matchedCards.OrderBy(i => i.Number).ToList();
                foreach (Card card in orderedCards)
                {
                    Console.WriteLine($"Kaart {card.Number}");
                }
            }          
        }
    }
}
