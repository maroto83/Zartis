using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket
{
    public class Rocket : IRocket
    {
        public ILandingArea LandingArea { get; }

        public Rocket(ILandingArea landingArea)
        {
            LandingArea = landingArea;
        }

        public LandingAnswers AskForPosition(Position position)
        {
            var landingAnswers = LandingArea.CheckPosition(position);

            return landingAnswers;
        }
    }
}