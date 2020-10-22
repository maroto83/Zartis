using Zartis.Rocket.Contracts;
using Zartis.Rocket.UnitTests.Builders.Mocks;

namespace Zartis.Rocket.UnitTests.Builders
{
    public class LandingAreaBuilder
    {
        private int _dimension;
        private ILandingPlatform _landingPlatform;

        public LandingAreaBuilder()
        {
            _dimension = 100;
            _landingPlatform = new LandingPlatformMockBuilder().Build();
        }

        public LandingAreaBuilder WithDimension(int dimension)
        {
            _dimension = dimension;
            return this;
        }

        public LandingAreaBuilder WithLandingPlatform(ILandingPlatform landingPlatform)
        {
            _landingPlatform = landingPlatform;
            return this;
        }

        public LandingArea Build()
        {
            var landingArea = new LandingArea(_dimension, _landingPlatform);

            return landingArea;
        }
    }
}