using FluentAssertions;
using Xunit;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.PositionTests
{
    public static class ConstructorTests
    {
        public class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private Position _sut;
            private int _x;
            private int _y;

            protected override void Given()
            {
                _x = 5;
                _y = 5;
            }

            protected override void When()
            {
                _sut = new Position(_x, _y);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }
        }
    }
}