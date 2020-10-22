using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Contracts
{
    public interface IRuleValidator
    {
        IRuleValidator SetNextRuleValidator(IRuleValidator ruleValidator);

        LandingAnswers Validate(Position position);
    }
}