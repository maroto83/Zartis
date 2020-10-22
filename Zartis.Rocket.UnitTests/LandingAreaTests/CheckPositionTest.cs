using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Zartis.Rocket.Enums;
using Zartis.Rocket.UnitTests.Builders;
using Zartis.Rocket.UnitTests.Builders.Mocks;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.LandingAreaTests
{
    public static class CheckPositionTest
    {
        public abstract class Given_A_LandingArea_When_Checking_A_Position
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;
            private IEnumerable<Position> _expectedPositions;

            protected abstract bool IsPositionInsideOfThePlatform { get; }
            protected abstract LandingAnswers LandingAnswer { get; }
            protected abstract IEnumerable<Position> StoredPositions { get; }

            protected override void Given()
            {
                _position = new PositionBuilder().Build();

                var landingPlatform =
                    new LandingPlatformMockBuilder()
                        .WithIsPositionInsideOfPlatformMocked(IsPositionInsideOfThePlatform)
                        .Build();

                _sut =
                    new LandingAreaBuilder()
                        .WithLandingPlatform(landingPlatform)
                        .Build();

                _expectedResult = LandingAnswer;
                _expectedPositions = StoredPositions;
            }

            protected override void When()
            {
                _result = _sut.CheckPosition(_position);
            }

            [Fact]
            public void Then_It_Should_Return_A_Valid_Result()
            {
                _result.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Have_The_ExpectedResult()
            {
                _result.Should().Be(_expectedResult);
            }

            [Fact]
            public void Then_StoredPositions_Should_Have_The_ExpectedPositions()
            {
                Zartis.Rocket.StoredPositions.Positions.Should().BeEquivalentTo(_expectedPositions);
            }
        }

        public class Given_A_LandingArea_When_Checking_A_Position_And_The_Position_Out_Of_The_Platform
            : Given_A_LandingArea_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => false;
            protected override LandingAnswers LandingAnswer => LandingAnswers.OutOfPlatform;
            protected override IEnumerable<Position> StoredPositions => new List<Position>();
        }

        public class Given_A_LandingArea_When_Checking_A_Position_And_The_Position_Is_Inside_Of_The_Platform
            : Given_A_LandingArea_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => true;
            protected override LandingAnswers LandingAnswer => LandingAnswers.OkForLanding;
            protected override IEnumerable<Position> StoredPositions => new PositionBuilder().BuildAsList();
        }

        public abstract class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private Position _positionTwo;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;
            private IEnumerable<Position> _expectedPositions;

            protected abstract bool IsPositionInsideOfThePlatform { get; }
            protected abstract bool IsAllowedPosition { get; }
            protected abstract LandingAnswers LandingAnswer { get; }
            protected abstract IEnumerable<Position> StoredPositions { get; }

            protected override void Given()
            {
                const int x = 5;
                const int y = 5;

                var positionOne =
                    new PositionBuilder()
                        .WithX(x)
                        .WithY(y)
                        .Build();

                _positionTwo =
                    new PositionBuilder()
                        .WithX(x + 2)
                        .WithY(y + 2)
                        .Build();

                var landingPlatform =
                    new LandingPlatformMockBuilder()
                        .WithIsPositionInsideOfPlatformMocked(IsPositionInsideOfThePlatform)
                        .WithIsAllowedPositionMocked(IsAllowedPosition)
                        .Build();

                _sut =
                    new LandingAreaBuilder()
                        .WithLandingPlatform(landingPlatform)
                        .Build();

                _sut.CheckPosition(positionOne);

                _expectedResult = LandingAnswer;
                _expectedPositions = StoredPositions;
            }

            protected override void When()
            {
                _result = _sut.CheckPosition(_positionTwo);
            }

            [Fact]
            public void Then_It_Should_Return_A_Valid_Result()
            {
                _result.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Have_The_ExpectedResult()
            {
                _result.Should().Be(_expectedResult);
            }

            [Fact]
            public void Then_StoredPositions_Should_Have_The_ExpectedPositions()
            {
                Zartis.Rocket.StoredPositions.Positions.Should().BeEquivalentTo(_expectedPositions);
            }
        }

        public class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position_And_The_Position_Is_Not_Allowed
            : Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => true;
            protected override bool IsAllowedPosition => false;
            protected override LandingAnswers LandingAnswer => LandingAnswers.Clash;
            protected override IEnumerable<Position> StoredPositions => new PositionBuilder().BuildAsList();
        }

        public class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position_And_The_Position_Is_Allowed
            : Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => true;
            protected override bool IsAllowedPosition => true;
            protected override LandingAnswers LandingAnswer => LandingAnswers.OkForLanding;
            protected override IEnumerable<Position> StoredPositions =>
                new List<Position>
                {
                    new PositionBuilder().Build(),
                    new PositionBuilder()
                        .WithX(7)
                        .WithY(7)
                        .Build()
                };
        }
    }
}