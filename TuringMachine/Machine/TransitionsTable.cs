using System;
using Machine.Enums;

namespace Machine
{
    public static class TransitionsTable
    {
        public static IEnumerable<Transition> Transitions() => new[]
        {
            new Transition(State.Q1, Head.Blank, Head.Blank, HeadDirection.Right, State.Accept),
            new Transition(State.Q1, '0', 'X', HeadDirection.Right, State.Q2),
            new Transition(State.Q1, 'Y', 'Y', HeadDirection.Right, State.Q4),
            new Transition(State.Q1, '1', '1', HeadDirection.Left, State.Reject),
            new Transition(State.Q1, 'X', 'X', HeadDirection.Left, State.Reject),
            
            new Transition(State.Q2, '0', 'Y', HeadDirection.Right, State.Q2),
            new Transition(State.Q2, 'Y', 'Y', HeadDirection.Right, State.Q2),
            new Transition(State.Q2, '1', 'Y', HeadDirection.Left, State.Q3),
            new Transition(State.Q2, 'X', 'X', HeadDirection.Left, State.Reject),
            new Transition(State.Q2, Head.Blank, Head.Blank, HeadDirection.Left, State.Reject),

            new Transition(State.Q3, '0', '0', HeadDirection.Left, State.Q3),
            new Transition(State.Q3, 'Y', 'Y', HeadDirection.Left, State.Q3),
            new Transition(State.Q3, 'X', 'X', HeadDirection.Right, State.Q1),
            new Transition(State.Q3, '1', '1', HeadDirection.Left, State.Reject),
            new Transition(State.Q3, Head.Blank, Head.Blank, HeadDirection.Left, State.Reject),
            
            new Transition(State.Q4, 'Y', 'Y', HeadDirection.Right, State.Q4),
            new Transition(State.Q4, Head.Blank, Head.Blank, HeadDirection.Right, State.Accept),
            new Transition(State.Q4, '1', '1', HeadDirection.Left, State.Reject),
            new Transition(State.Q4, '0', '0', HeadDirection.Left, State.Reject),
            new Transition(State.Q4, 'X', 'X', HeadDirection.Left, State.Reject),

            new Transition(State.Accept, '0', '0', HeadDirection.Left, State.Accept),
            new Transition(State.Accept, '1', '1', HeadDirection.Left, State.Accept),
            new Transition(State.Accept, 'X', 'X', HeadDirection.Left, State.Accept),
            new Transition(State.Accept, 'Y', 'Y', HeadDirection.Left, State.Accept),
            new Transition(State.Accept, Head.Blank, Head.Blank, HeadDirection.Left, State.Accept),

        };
    }
}
