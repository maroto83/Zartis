using FluentAssertions;
using Moq;
using Xunit;
using Zartis.Rocket.Contracts;
using Zartis.Rocket.Enums;
using Zartis.Rocket.UnitTests.TestSupport;

namespace Zartis.Rocket.UnitTests.RocketTests
{
    public static class AskForPositionTests
    {
        public abstract class Given_One_Rocket_When_Asking_For_A_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;

            protected abstract LandingAnswers LandingAnswer { get; }

            protected override void Given()
            {
                const int x = 5;
                const int y = 5;

                _position = new Position(x, y);

                var landingAreaMock = new Mock<ILandingArea>();

                landingAreaMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(LandingAnswer);

                var landingArea = landingAreaMock.Object;
                _sut = new Rocket(landingArea);

                _expectedResult = LandingAnswer;
            }

            protected override void When()
            {
                _result = _sut.AskForPosition(_position);
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
        }

        public class Given_One_Rocket_When_Asking_For_A_Position_And_Answer_Is_OkForLanding
                : Given_One_Rocket_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.OkForLanding;
        }

        public class Given_One_Rocket_When_Asking_For_A_Position_And_Answer_Is_Clash
            : Given_One_Rocket_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.Clash;
        }

        public class Given_One_Rocket_When_Asking_For_A_Position_And_Answer_Is_OutOfPlatform
            : Given_One_Rocket_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.OutOfPlatform;
        }

        public abstract class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;

            protected abstract LandingAnswers LandingAnswerForRocketTwo { get; }

            protected override void Given()
            {
                const int x = 5;
                const int y = 5;
                const LandingAnswers landingAnswerForRocketOne = LandingAnswers.OkForLanding;

                _position = new Position(x, y);

                var landingAreaForRocketOneMock = new Mock<ILandingArea>();

                landingAreaForRocketOneMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(landingAnswerForRocketOne);

                var landingAreaForRocketOne = landingAreaForRocketOneMock.Object;

                var rocketOne = new Rocket(landingAreaForRocketOne);
                rocketOne.AskForPosition(_position);

                var landingAreaForRocketTwoMock = new Mock<ILandingArea>();

                landingAreaForRocketTwoMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(LandingAnswerForRocketTwo);

                var landingAreaForRocketTwo = landingAreaForRocketTwoMock.Object;

                _sut = new Rocket(landingAreaForRocketTwo);

                _expectedResult = LandingAnswerForRocketTwo;
            }

            protected override void When()
            {
                _result = _sut.AskForPosition(_position);
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
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position_And_The_RocketTwo_Is_OkForLanding
            : Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OutOfPlatform;
        }

        public abstract class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;

            protected abstract LandingAnswers LandingAnswerForRocketTwo { get; }

            protected override void Given()
            {
                const int x = 5;
                const int y = 5;
                const LandingAnswers landingAnswerForRocketOne = LandingAnswers.Clash;

                _position = new Position(x, y);

                var landingAreaForRocketOneMock = new Mock<ILandingArea>();

                landingAreaForRocketOneMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(landingAnswerForRocketOne);

                var landingAreaForRocketOne = landingAreaForRocketOneMock.Object;

                var rocketOne = new Rocket(landingAreaForRocketOne);
                rocketOne.AskForPosition(_position);

                var landingAreaForRocketTwoMock = new Mock<ILandingArea>();

                landingAreaForRocketTwoMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(LandingAnswerForRocketTwo);

                var landingAreaForRocketTwo = landingAreaForRocketTwoMock.Object;

                _sut = new Rocket(landingAreaForRocketTwo);

                _expectedResult = LandingAnswerForRocketTwo;
            }

            protected override void When()
            {
                _result = _sut.AskForPosition(_position);
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
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_OkForLanding
            : Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OutOfPlatform;
        }

        public abstract class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;

            protected abstract LandingAnswers LandingAnswer { get; }

            protected override void Given()
            {
                const int x = 5;
                const int y = 5;
                const LandingAnswers landingAnswerForRocketOne = LandingAnswers.OutOfPlatform;

                _position = new Position(x, y);

                var landingAreaForRocketOneMock = new Mock<ILandingArea>();

                landingAreaForRocketOneMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(landingAnswerForRocketOne);

                var landingAreaForRocketOne = landingAreaForRocketOneMock.Object;

                var rocketOne = new Rocket(landingAreaForRocketOne);
                rocketOne.AskForPosition(_position);

                var landingAreaForRocketTwoMock = new Mock<ILandingArea>();

                landingAreaForRocketTwoMock
                    .Setup(area => area.CheckPosition(_position))
                    .Returns(LandingAnswer);

                var landingAreaForRocketTwo = landingAreaForRocketTwoMock.Object;

                _sut = new Rocket(landingAreaForRocketTwo);

                _expectedResult = LandingAnswer;
            }

            protected override void When()
            {
                _result = _sut.AskForPosition(_position);
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
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_OkForLanding
            : Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position
        {
            protected override LandingAnswers LandingAnswer => LandingAnswers.OutOfPlatform;
        }
    }
}