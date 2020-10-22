using FluentAssertions;
using Xunit;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.UnitTests.Builders.Mocks;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.LandingAreaTests
{
    public static class ConstructorTests
    {
        public class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private int _dimension;
            private ILandingPlatform _landingPlatform;

            protected override void Given()
            {
                _dimension = 100;
                _landingPlatform = new LandingPlatformMockBuilder().Build();
            }

            protected override void When()
            {
                _sut = new LandingArea(_dimension, _landingPlatform);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_A_ILandingArea()
            {
                _sut.Should().BeAssignableTo<ILandingArea>();
            }
        }
    }
}