using System;

namespace Machine.Exceptions
{
    public class TimeExcededException : Exception
    {
        public override string Message => "Time exceded, Turing Machine could not solve.";
    }
}
