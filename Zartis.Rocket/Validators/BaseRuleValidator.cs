using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Validators
{
    public abstract class BaseRuleValidator
        : IRuleValidator
    {
        private IRuleValidator _nextRuleValidator;

        public IRuleValidator SetNextRuleValidator(IRuleValidator ruleValidator)
        {
            _nextRuleValidator = ruleValidator;

            return ruleValidator;
        }

        public virtual LandingAnswers Validate(Position position)
        {
            return _nextRuleValidator.Validate(position);
        }
    }
}