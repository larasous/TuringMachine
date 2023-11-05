using System;
using Machine.Enums;

namespace Machine
{
    public class Transition
    {
        public State CurrentState { get; }
        public char Read { get; }
        public char Write { get; }
        public HeadDirection HeadDirection { get; }
        public State NextState { get; }

        public Transition(State initialState, char read, char write, HeadDirection headDirection, State nextState)
        {
            CurrentState = initialState;
            Read = read;
            Write = write;
            HeadDirection = headDirection;
            NextState = nextState;
        }
    }
}
