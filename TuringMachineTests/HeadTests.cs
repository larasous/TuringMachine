using Machine;
using Machine.Enums;

namespace TuringMachineTests
{
    [TestFixture]
    public class HeadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Ignore("Not implemented yet")]
        [Test]
        public void Constructor_When_TapeIsNull_Then_ReturnThrowsArgumentNullException_()
        {
            // Arrange
            IEnumerable<char> nullTape = null;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => new Head(nullTape, HeadDirection.Left));
        }

        [Test]
        public void Constructor_When_TapeIsEmpty_Then_ReturnThrowsArgumentNullException_()
        {
            // Arrange
            IEnumerable<char> emptyTape = new List<char>(); // Cria uma fita vazia

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() => new Head(emptyTape, HeadDirection.NoMove));
            Assert.AreEqual("Tape must not be empty.", exception.Message); // Verifica se a mensagem da exce��o corresponde � mensagem esperada
        }

        [TestCase("0011", 'X', 0, "X011")] // Escrever 'X' na primeira posi��o da fita vazia resulta em uma fita com um �nico caractere 'X'
        [TestCase("01", 'Y', 0, "Y1")] // Escrever 'Y' na posi��o 0 da fita "01" resulta na fita "Y1"
        public void Write_When_CorrectIndex_Then_WriteSymbol(string initialTapeString, char symbolToWrite, int writeIndex, string expectedTapeString)
        {
            // Arrange
            IEnumerable<char> initialTape = initialTapeString.ToCharArray();
            Head head = new Head(HeadDirection.NoMove, initialTape);

            // Act
            Head newHead = head.Write(symbolToWrite, writeIndex);

            // Assert
            char[] updatedTape = newHead.Tape.ToArray();
            string actualTapeString = new string(updatedTape);
            Assert.AreEqual(expectedTapeString, actualTapeString, $"Esperava '{expectedTapeString}' ap�s escrever '{symbolToWrite}' na posi��o {writeIndex}");
        }

        [Test]
        [TestCase("01", 'X', -1)] // Tentar escrever em um �ndice negativo deve lan�ar IndexOutOfRangeException
        [TestCase("0011", 'X', 10)]  // Tentar escrever em um �ndice fora dos limites da fita deve lan�ar IndexOutOfRangeException
        public void Write_When_IncorrectIndex_Then_ReturnThrowsExceptionForInvalidIndex(string initialTape, char symbolToWrite, int writeIndex)
        {
            // Arrange
            IEnumerable<char> tape = initialTape.ToCharArray();
            Head head = new Head(HeadDirection.NoMove, tape);

            // Act + Assert
            Assert.Throws<IndexOutOfRangeException>(() => head.Write(symbolToWrite, writeIndex));
        }
    }
}