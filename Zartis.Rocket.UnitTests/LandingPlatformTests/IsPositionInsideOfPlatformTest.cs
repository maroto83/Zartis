using FluentAssertions;
using Xunit;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.LandingPlatformTests
{
    public static class IsPositionInsideOfPlatformTest
    {
        public abstract class Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private bool _result;
            private bool _expectedResult;

            protected abstract Position StartPosition { get; }
            protected abstract Position NewPosition { get; }
            protected abstract bool IsInsideOfPlatform { get; }

            protected override void Given()
            {
                const int size = 10;

                _sut = new LandingPlatform(size, StartPosition);

                _expectedResult = IsInsideOfPlatform;
            }

            protected override void When()
            {
                _result = _sut.IsPositionInsideOfPlatform(NewPosition);
            }

            [Fact]
            public void Then_It_Should_Have_The_ExpectedResult()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public class Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform_And_The_Position_Is_Inside_Of_Platform
            : Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform
        {
            protected override Position StartPosition => new Position(5, 5);
            protected override Position NewPosition => new Position(7, 7);
            protected override bool IsInsideOfPlatform => true;
        }

        public class Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform_And_The_Position_Is_Not_Inside_Of_Platform
            : Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform
        {
            protected override Position StartPosition => new Position(5, 5);
            protected override Position NewPosition => new Position(16, 7);
            protected override bool IsInsideOfPlatform => false;
        }
    }
}