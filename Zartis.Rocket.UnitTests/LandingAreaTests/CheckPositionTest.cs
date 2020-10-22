using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;
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
                const int x = 5;
                const int y = 5;
                const int dimension = 100;

                _position = new Position(x, y);

                var landingPlatformMock = new Mock<ILandingPlatform>();

                landingPlatformMock
                    .Setup(platform => platform.IsPositionInsideOfPlatform(_position))
                    .Returns(IsPositionInsideOfThePlatform);

                var landingPlatform = landingPlatformMock.Object;

                _sut = new LandingArea(dimension, landingPlatform);

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
            protected override IEnumerable<Position> StoredPositions => new List<Position> { new Position(5, 5) };
        }

        public abstract class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private Position _position;
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
                const int dimension = 100;

                var positionOne = new Position(x, y);
                _position = new Position(x + 2, y + 2);

                var landingPlatformMock = new Mock<ILandingPlatform>();

                landingPlatformMock
                    .Setup(platform => platform.IsPositionInsideOfPlatform(It.IsAny<Position>()))
                    .Returns(IsPositionInsideOfThePlatform);

                landingPlatformMock
                    .Setup(platform => platform.IsAllowedPosition(It.IsAny<IEnumerable<Position>>(), _position))
                    .Returns(IsAllowedPosition);

                var landingPlatform = landingPlatformMock.Object;

                _sut = new LandingArea(dimension, landingPlatform);

                _sut.CheckPosition(positionOne);

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

        public class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position_And_The_Position_Is_Not_Allowed
            : Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => true;
            protected override bool IsAllowedPosition => false;
            protected override LandingAnswers LandingAnswer => LandingAnswers.Clash;
            protected override IEnumerable<Position> StoredPositions => new List<Position> { new Position(5, 5) };
        }

        public class Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position_And_The_Position_Is_Allowed
            : Given_A_LandingArea_With_A_Previous_Stored_Position_When_Checking_A_Position
        {
            protected override bool IsPositionInsideOfThePlatform => true;
            protected override bool IsAllowedPosition => true;
            protected override LandingAnswers LandingAnswer => LandingAnswers.OkForLanding;
            protected override IEnumerable<Position> StoredPositions => new List<Position> { new Position(5, 5), new Position(7, 7) };
        }
    }
}