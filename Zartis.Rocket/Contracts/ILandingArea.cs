using Zartis.Rocket.Enums;

namespace Zartis.Rocket.Contracts
{
    public interface ILandingArea
    {
        LandingAnswers CheckPosition(Position position);
    }
}