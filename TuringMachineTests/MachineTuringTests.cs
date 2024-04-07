using Machine.Enums;
using Machine;

namespace TuringMachineTests
{
    [TestFixture]
    public class MachineTuringTests
    {
        [TestCase("101", false)] // Teste com entrada "101" que deve ser rejeitada (false)
        [TestCase("0101", false)] // Teste com entrada "0101" que deve ser rejeitada (false)
        [TestCase("000111", true)] // Teste com entrada "000111" que deve ser aceita (true)
        [TestCase("0000000011111111", true)] // Teste com entrada "0000000011111111" que deve ser aceita (true)
        public void MachineTuring_Run_ReturnsExpectedOutput(string input, bool expectedResult)
        {
            // Arrange
            IEnumerable<Transition> transitionTable = TransitionsTable.Transitions();
            Head head = new Head(input, HeadDirection.NoMove);
            MachineTuring turingMachine = new MachineTuring(input, (int)State.Q1, head, transitionTable);

            // Act
            turingMachine.Run();

            // Assert
            bool result = turingMachine.IsAccepted;
            Assert.That(result, Is.EqualTo(expectedResult), $"A máquina de Turing {(result ? "aceita" : "rejeita")} a entrada '{input}'");
        }
    }
}
