using Zartis.Rocket.Contracts;
using Zartis.Rocket.UnitTests.Builders.Mocks;

namespace Zartis.Rocket.UnitTests.Builders
{
    public class RocketBuilder
    {
        private ILandingArea _landingArea;

        public RocketBuilder()
        {
            _landingArea = new LandingAreaMockBuilder().Build();
        }

        public RocketBuilder WithLandingArea(ILandingArea landingArea)
        {
            _landingArea = landingArea;
            return this;
        }

        public Rocket Build()
        {
            var rocket = new Rocket(_landingArea);

            return rocket;
        }
    }
}