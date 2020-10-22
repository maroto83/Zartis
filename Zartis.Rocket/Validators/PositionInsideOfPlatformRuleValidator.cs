using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Validators
{
    public class PositionInsideOfPlatformRuleValidator
        : BaseRuleValidator
    {
        public ILandingPlatform LandingPlatform { get; }

        public PositionInsideOfPlatformRuleValidator(ILandingPlatform landingPlatform)
        {
            LandingPlatform = landingPlatform;
        }

        public override LandingAnswers Validate(Position position)
        {
            return
                !LandingPlatform.IsPositionInsideOfPlatform(position)
                    ? LandingAnswers.OutOfPlatform
                    : base.Validate(position);
        }
    }
}