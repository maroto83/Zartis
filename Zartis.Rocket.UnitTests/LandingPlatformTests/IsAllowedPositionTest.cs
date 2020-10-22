using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Zartis.Rocket.UnitTests.Builders;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.LandingPlatformTests
{
    public static class IsAllowedPositionTest
    {
        public abstract class Given_A_LandingPlatform_When_Checking_IsAllowedPositionTest
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private bool _result;
            private bool _expectedResult;

            protected abstract Position StartPosition { get; }
            protected abstract Position NewPosition { get; }
            protected abstract List<Position> StoredPositions { get; }
            protected abstract bool IsAllowed { get; }

            protected override void Given()
            {
                _sut =
                    new LandingPlatformBuilder()
                        .WithStartPosition(StartPosition)
                        .Build();

                _expectedResult = IsAllowed;
            }

            protected override void When()
            {
                _result = _sut.IsAllowedPosition(StoredPositions, NewPosition);
            }

            [Fact]
            public void Then_It_Should_Have_The_ExpectedResult()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public class Given_A_LandingPlatform_When_Checking_IsAllowedPositionTest_And_The_Position_Is_Allowed
            : Given_A_LandingPlatform_When_Checking_IsAllowedPositionTest
        {
            protected override Position StartPosition => new PositionBuilder().Build();
            protected override Position NewPosition => new PositionBuilder().WithX(7).WithY(7).Build();
            protected override List<Position> StoredPositions => new PositionBuilder().BuildAsList();
            protected override bool IsAllowed => true;
        }

        public class Given_A_LandingPlatform_When_Checking_IsAllowedPositionTest_And_The_Position_Is_Not_Allowed
            : Given_A_LandingPlatform_When_Checking_IsAllowedPositionTest
        {
            protected override Position StartPosition => new PositionBuilder().Build();
            protected override Position NewPosition => new PositionBuilder().WithX(6).WithY(6).Build();
            protected override List<Position> StoredPositions => new PositionBuilder().BuildAsList();
            protected override bool IsAllowed => false;
        }
    }
}