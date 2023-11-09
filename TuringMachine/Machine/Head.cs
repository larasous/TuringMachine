using System;
using System.Linq;
using Machine.Enums;

namespace Machine
{
    public class Head
    {
        public const char Blank = '-';
        public HeadDirection Direction { get; }
        public IEnumerable<char> Tape { get; }

        private string GetChar(char c, int index) => index == (int)Direction ? $"({c})" : c.ToString();

        public Head(IEnumerable<char> tape, HeadDirection headPosition)
        {
            if (tape == null)
                throw new ArgumentNullException(nameof(tape));

            var safeData = (new string(tape.ToArray()) + Head.Blank).ToCharArray();

            if ((int) headPosition < 0 || (int) headPosition >= safeData.Length)
                throw new IndexOutOfRangeException("Invalid head position");

            Tape = safeData;
            Direction = headPosition;
        }

        public Head(HeadDirection direction, IEnumerable<char> tape)
        {
            Direction = direction;
            Tape = tape;
        }

        public Head MoveLeft() => Direction == 0 ? new Head(HeadDirection.NoMove, Tape) : new Head(HeadDirection.Left, Tape);
        public Head MoveRight() => Direction == 0 ? new Head(HeadDirection.NoMove, Tape) : new Head(HeadDirection.Right, Tape);

        public Head Write(char symbolWrite, int currentIndex)
        {
            char[] tapeArray = Tape.ToArray();
            if (currentIndex >= 0 && currentIndex < tapeArray.Length)
            {
                   tapeArray[currentIndex] = symbolWrite;
            }
            return new Head(tapeArray, Direction);
        }

        public char Read() => Tape.ElementAt((int) Direction);

        public Head Move(HeadDirection direction)
        {
            return direction switch
            {
                HeadDirection.Left => MoveLeft(),
                HeadDirection.NoMove => this,
                HeadDirection.Right => MoveRight(),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
            };
        }

        public override string ToString() => $@"Tape: {Tape.Select(GetChar).Aggregate((agg, next) => agg + next)}";

    }
}
