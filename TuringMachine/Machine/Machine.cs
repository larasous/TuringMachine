using Machine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Machine
{
    public class Machine
    {
        public int InitialState { get; set; }
        public int CurrentState { get; set; }
        public bool IsAccepted { get; set; }
        public Head Head { get; set;  }
        public IEnumerable<Transition> TransitionTable { get; }

        public Machine(int state, Head head, IEnumerable<Transition> transitionTable)
        {
            InitialState = state;
            CurrentState = InitialState;
            Head = head ?? throw new ArgumentNullException(nameof(head));
            TransitionTable = transitionTable ?? throw new ArgumentNullException(nameof(transitionTable));
        }
 
        public void Run()
        {
            foreach (char symbol in Head.Tape)
            {
                var validTransitions = TransitionTable
                                    .Where(t => (int)t.CurrentState == CurrentState && t.Read == symbol)
                                    .ToList();
                if (!validTransitions.Any())
                {
                    CurrentState = -1; // Indica rejeição
                    break;
                }

                var chosenTransition = validTransitions.First();
                CurrentState = (int)chosenTransition.NextState;
                Head = Head.Write(chosenTransition.Read).Move(chosenTransition.HeadDirection);
            }
            IsAccepted = CurrentState == (int)State.Accept;
        }
    }
}
