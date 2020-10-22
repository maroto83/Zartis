using System.Linq;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Validators
{
    public class PositionNotAllowedRuleValidator
        : BaseRuleValidator
    {
        public ILandingPlatform LandingPlatform { get; }

        public PositionNotAllowedRuleValidator(ILandingPlatform landingPlatform)
        {
            LandingPlatform = landingPlatform;
        }
        public override LandingAnswers Validate(Position position)
        {
            return
                StoredPositions.Positions
                    .Any(askedPosition => !LandingPlatform.IsAllowedPosition(StoredPositions.Positions, position))
                    ? LandingAnswers.Clash
                    : base.Validate(position);
        }
    }
}