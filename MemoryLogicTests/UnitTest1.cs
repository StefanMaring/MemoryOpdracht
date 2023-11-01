using MemoryLogic;

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


    }
}