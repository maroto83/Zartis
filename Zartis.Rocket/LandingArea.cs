using System.Collections.Generic;
using System.Linq;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket
{
    public class LandingArea
        : ILandingArea
    {
        public ILandingPlatform LandingPlatform { get; }
        public int Dimension { get; }
        private static IEnumerable<Position> Positions => StoredPositions.Positions;

        public LandingArea(in int dimension, ILandingPlatform landingPlatform)
        {
            Dimension = dimension;
            LandingPlatform = landingPlatform;
            StoredPositions.Positions = new List<Position>();
        }

        public LandingAnswers CheckPosition(Position position)
        {
            if (!LandingPlatform.IsPositionInsideOfPlatform(position))
            {
                return LandingAnswers.OutOfPlatform;
            }

            if (!Positions.Any())
            {
                StoredPositions.Positions.Add(position);

                return LandingAnswers.OkForLanding;
            }

            if (Positions.Any(askedPosition => !LandingPlatform.IsAllowedPosition(Positions, position)))
            {
                return LandingAnswers.Clash;
            }

            StoredPositions.Positions.Add(position);

            return LandingAnswers.OkForLanding;
        }
    }
}