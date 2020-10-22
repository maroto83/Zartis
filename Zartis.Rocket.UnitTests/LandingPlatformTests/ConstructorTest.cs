using FluentAssertions;
using Xunit;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.LandingPlatformTests
{
    public static class ConstructorTests
    {
        public class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private int _size;
            private Position _startPosition;

            protected override void Given()
            {
                _size = 10;
                _startPosition = new Position(5, 5);
            }

            protected override void When()
            {
                _sut = new LandingPlatform(_size, _startPosition);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_A_ILandingPlatform()
            {
                _sut.Should().BeAssignableTo<ILandingPlatform>();
            }
        }
    }
}