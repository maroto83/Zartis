using System.Linq;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Validators
{
    public class FirstPositionRuleValidator
        : BaseRuleValidator
    {
        public override LandingAnswers Validate(Position position)
        {
            if (!StoredPositions.Positions.Any())
            {
                StoredPositions.Positions.Add(position);

                return LandingAnswers.OkForLanding;
            }

            return base.Validate(position);
        }
    }
}