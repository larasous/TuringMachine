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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Ignore("Not implemented yet")]
        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenTapeIsNull()
        {
            // Arrange
            IEnumerable<char> nullTape = null;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => new Head(nullTape, HeadDirection.Left));
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenTapeIsEmpty()
        {
            // Arrange
            IEnumerable<char> emptyTape = new List<char>(); // Cria uma fita vazia

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() => new Head(emptyTape, HeadDirection.NoMove));
            Assert.AreEqual("Tape must not be empty.", exception.Message); // Verifica se a mensagem da exceção corresponde à mensagem esperada
        }

    }
}