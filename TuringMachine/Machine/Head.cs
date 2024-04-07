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

        public Head(IEnumerable<char> tape, HeadDirection headPosition)
        {
            if (!tape.Any())
            {
                throw new ArgumentException("Tape must not be empty.");
            }

            var safeData = (new string(tape.ToArray()) + Head.Blank).ToCharArray();

            //if ((int)headPosition < 0 || (int)headPosition >= safeData.Length)
            //    throw new IndexOutOfRangeException();

            Tape = safeData;
            Direction = headPosition;
        }

        public Head(HeadDirection direction, IEnumerable<char> tape)
        {
            if (tape == null)
                throw new ArgumentNullException();
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
            return new Head(Direction, tapeArray);
        }

        public char Read(int currentIndex) => Tape.ElementAt(currentIndex);

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

    }
}
