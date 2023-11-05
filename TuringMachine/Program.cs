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

            Machine.Machine turingMachine = new Machine.Machine((int) State.Q1, head, transitionTable);

            turingMachine.Run();

            if (turingMachine.IsAccepted)
            {
                Console.WriteLine("Máquina aceitou a entrada.");
            }
            else
            {
                Console.WriteLine("Máquina rejeitou a entrada.");
            }
        }
    }
}
