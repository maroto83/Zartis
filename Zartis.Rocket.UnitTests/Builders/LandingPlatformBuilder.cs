namespace Zartis.Rocket.UnitTests.Builders
{
    public class LandingPlatformBuilder
    {
        private int _size;
        private Position _startPosition;

        public LandingPlatformBuilder()
        {
            _size = 10;
            _startPosition = new PositionBuilder().Build();
        }

        public LandingPlatformBuilder WithSize(int size)
        {
            _size = size;
            return this;
        }

        public LandingPlatformBuilder WithStartPosition(Position startPosition)
        {
            _startPosition = startPosition;
            return this;
        }

        public LandingPlatform Build()
        {
            var landingPlatform = new LandingPlatform(_size, _startPosition);

            return landingPlatform;
        }
    }
}