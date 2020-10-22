using Moq;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;

namespace Zartis.Rocket.UnitTests.Builders.Mocks
{
    public class LandingAreaMockBuilder
    {
        private readonly Mock<ILandingArea> _landingAreaMock;

        public LandingAreaMockBuilder()
        {
            _landingAreaMock = new Mock<ILandingArea>();
        }

        public LandingAreaMockBuilder WithCheckPositionMocked(LandingAnswers landingAnswer, Position position = null)
        {
            _landingAreaMock
                .Setup(landingArea => landingArea.CheckPosition(position ?? It.IsAny<Position>()))
                .Returns(landingAnswer);

            return this;
        }

        public ILandingArea Build()
        {
            var landingArea = _landingAreaMock.Object;

            return landingArea;
        }
    }
}
