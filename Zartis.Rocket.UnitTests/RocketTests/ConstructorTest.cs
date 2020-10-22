using FluentAssertions;
using Moq;
using Xunit;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.RocketTests
{
    public static class ConstructorTests
    {
        public class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private ILandingArea _landingArea;

            protected override void Given()
            {
                _landingArea = Mock.Of<ILandingArea>();
            }

            protected override void When()
            {
                _sut = new Rocket(_landingArea);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_A_IRocket()
            {
                _sut.Should().BeAssignableTo<IRocket>();
            }
        }
    }
}