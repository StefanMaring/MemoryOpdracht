﻿namespace MemoryLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                Console.WriteLine("Geef aan met hoeveel kaarten je wilt spelen:");
                int amount = int.Parse(Console.ReadLine());
                Game MemoryGame = new Game(amount);                
            } catch (FormatException)
            {
                Console.WriteLine("Alleen getallen zijn toegestaan!");
            }         
        }
    }
}