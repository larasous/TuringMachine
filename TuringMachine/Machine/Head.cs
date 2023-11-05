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

        //public void SetInput(IEnumerable<char> input, IEnumerable<char> tape) => tape = input;

        public Head MoveLeft() => Direction == 0 ? new Head(Tape, 0) : new Head(Tape, Direction - 1);
        public Head MoveRight() => Direction == 0 ? new Head(Tape, Direction + 1) : new Head(Tape, Direction + 1);

        public Head Write(char head)
        {
            char[] tapeArray = Tape.ToArray();
            if ((int)Direction < tapeArray.Length)
            {
                if (head == '0')
                {
                    tapeArray[(int)Direction] = 'X';
                }
                else if (head == '1')
                {
                    tapeArray[(int)Direction] = 'Y';
                }
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
