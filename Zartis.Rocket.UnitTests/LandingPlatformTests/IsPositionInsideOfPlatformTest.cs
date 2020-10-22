using FluentAssertions;
using Xunit;
using Zartis.Rocket.UnitTests.Builders;
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
                _sut =
                    new LandingPlatformBuilder()
                        .WithStartPosition(StartPosition)
                        .Build();

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
            protected override Position StartPosition => new PositionBuilder().Build();
            protected override Position NewPosition => new PositionBuilder().WithX(7).WithY(7).Build();
            protected override bool IsInsideOfPlatform => true;
        }

        public class Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform_And_The_Position_Is_Not_Inside_Of_Platform
            : Given_A_LandingPlatform_When_Checking_IsPositionInsideOfPlatform
        {
            protected override Position StartPosition => new PositionBuilder().Build();
            protected override Position NewPosition => new PositionBuilder().WithX(16).WithY(7).Build();
            protected override bool IsInsideOfPlatform => false;
        }
    }
}