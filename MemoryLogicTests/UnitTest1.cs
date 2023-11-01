using MemoryLogic;
using System.Net.Sockets;

namespace MemoryLogicTests
{
    public class Tests
    {
        [TestCase(8,8)]
        [TestCase(13,14)]
        [TestCase(10,10)]
        [TestCase(9,10)]
        public void DetermineAmountOfCards_SetAmount_SetsCorrectAmount(int amount, int expectedAmount)
        {
            Game game = new Game();
            game.DetermineAmountOfCards(amount);

            int expectedResult = game.AmountOfCards;

            Assert.That(expectedResult, Is.EqualTo(expectedAmount));
        }

        [TestCase(6, false)]
        [TestCase(22, false)]
        public void DetermineAmountOfCards_SetAmount_ReturnFalse(int input, bool returnValue)
        {
            Game game = new Game();
            bool expectedResult = game.DetermineAmountOfCards(input);

            Assert.That(expectedResult, Is.EqualTo(returnValue));
        }

        [TestCase(8)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(20)]
        public void CreateCardValues_CreateArray_HasCreatedArray(int amount)
        {
            Game game = new Game();
            string[] testValues = game.CreateCardValues(amount);

            int expectedResult = testValues.Length;

            Assert.That(expectedResult, Is.EqualTo(amount));
        }

        //[TestCase(8)]
        //[TestCase(10)]
        //[TestCase(12)]
        //[TestCase(20)]
        //public void CreateCards_HasCreatedCorrectCardAmount(int amount) { 
        //    Game game = new Game();
        //    game.CreateCards(amount);

        //    List<Card> gameCards = game.GameCards;

        //    int expectedResult = gameCards.Count;

        //    Assert.That(expectedResult, Is.EqualTo(amount));
        //}

        [TestCase(10,20,5,1000.0)]
        [TestCase(4,20,2,400.0)]
        [TestCase(4,10,2,800.0)]
        [TestCase(4,10,3,534.0)]
        public void CalculateScore(int amountOfCards, int timeTillCompletion, int turnAmount, double expectedScore) {
            ScoreCalculator sc = new ScoreCalculator(amountOfCards, timeTillCompletion, turnAmount);
            double actualScore = sc.CalculateScore();

            Assert.That(expectedScore, Is.EqualTo(actualScore));
        }
    }
}