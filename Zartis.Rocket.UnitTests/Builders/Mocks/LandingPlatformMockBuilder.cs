using Moq;
using System.Collections.Generic;
using Zartis.Rocket.Contracts;

namespace Zartis.Rocket.UnitTests.Builders.Mocks
{
    public class LandingPlatformMockBuilder
    {
        private readonly Mock<ILandingPlatform> _landingPlatformMock;

        public LandingPlatformMockBuilder()
        {
            _landingPlatformMock = new Mock<ILandingPlatform>();
        }

        public LandingPlatformMockBuilder WithIsPositionInsideOfPlatformMocked(bool isInsideOfPlatform)
        {
            _landingPlatformMock
                .Setup(landingPlatform => landingPlatform.IsPositionInsideOfPlatform(It.IsAny<Position>()))
                .Returns(isInsideOfPlatform);

            return this;
        }

        public LandingPlatformMockBuilder WithIsAllowedPositionMocked(bool isAllowed)
        {
            _landingPlatformMock
                .Setup(landingPlatform => landingPlatform.IsAllowedPosition(It.IsAny<List<Position>>(), It.IsAny<Position>()))
                .Returns(isAllowed);

            return this;
        }

        public ILandingPlatform Build()
        {
            var landingPlatform = _landingPlatformMock.Object;

            return landingPlatform;
        }
    }
}
