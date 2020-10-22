using System;
using System.Collections.Generic;
using System.Linq;
using Zartis.Rocket.Contracts;

namespace Zartis.Rocket
{
    public class LandingPlatform
        : ILandingPlatform
    {
        public Position StartPosition { get; }
        public int Size { get; }

        public LandingPlatform(int size, Position startPosition)
        {
            Size = size;
            StartPosition = startPosition;
        }

        public bool IsPositionInsideOfPlatform(Position position)
        {
            return position.X >= StartPosition.X
                   && position.X <= StartPosition.X + Size
                   && position.Y >= StartPosition.Y
                   && position.Y <= StartPosition.Y + Size;
        }

        public bool IsAllowedPosition(IEnumerable<Position> storedPositions, Position position)
        {
            return
                storedPositions
                    .All(
                        storedPosition => Math.Abs(storedPosition.X - position.X) > 1
                                                || Math.Abs(storedPosition.Y - position.Y) > 1);
        }
    }
}