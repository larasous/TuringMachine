using System;
using Machine;
using Machine.Enums;

namespace TuringMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<Transition> transitionTable = TransitionsTable.Transitions();

            Console.Write("Digite a entrada para a máquina de Turing: ");
            string input = Console.ReadLine();

            Head head = new Head(input, HeadDirection.NoMove);

            MachineTuring turingMachine = new MachineTuring(input, (int)State.Q1, head, transitionTable);

            turingMachine.Run();

            Console.WriteLine(turingMachine);
        }
    }
}
