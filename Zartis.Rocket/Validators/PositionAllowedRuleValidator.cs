using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Validators
{
    public class PositionAllowedRuleValidator
        : BaseRuleValidator
    {
        public override LandingAnswers Validate(Position position)
        {
            StoredPositions.Positions.Add(position);
            return LandingAnswers.OkForLanding;
        }
    }
}