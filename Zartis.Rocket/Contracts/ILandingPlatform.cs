using System.Collections.Generic;

namespace Zartis.Rocket.Contracts
{
    public interface ILandingPlatform
    {
        bool IsPositionInsideOfPlatform(Position position);
        bool IsAllowedPosition(IEnumerable<Position> storedPositions, Position position);
    }
}