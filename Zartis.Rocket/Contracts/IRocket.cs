using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Contracts
{
    public interface IRocket
    {
        LandingAnswers AskForPosition(Position position);
    }
}