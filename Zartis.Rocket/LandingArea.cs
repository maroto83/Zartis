using System.Collections.Generic;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;
using Zartis.Rocket.Validators;

namespace Zartis.Rocket
{
    public class LandingArea
        : ILandingArea
    {
        public ILandingPlatform LandingPlatform { get; }
        public int Dimension { get; }

        public LandingArea(in int dimension, ILandingPlatform landingPlatform)
        {
            Dimension = dimension;
            LandingPlatform = landingPlatform;
            StoredPositions.Positions = new List<Position>();
        }

        public LandingAnswers CheckPosition(Position position)
        {
            var positionInsideOfPlatformRuleValidator = new PositionInsideOfPlatformRuleValidator(LandingPlatform);
            var firstPositionRuleValidator = new FirstPositionRuleValidator();
            var positionNotAllowedRuleValidator = new PositionNotAllowedRuleValidator(LandingPlatform);
            var positionAllowedRuleValidator = new PositionAllowedRuleValidator();

            positionInsideOfPlatformRuleValidator
                .SetNextRuleValidator(firstPositionRuleValidator)
                .SetNextRuleValidator(positionNotAllowedRuleValidator)
                .SetNextRuleValidator(positionAllowedRuleValidator);

            var landingAnswers = positionInsideOfPlatformRuleValidator.Validate(position);

            return landingAnswers;
        }
    }
}