using FluentAssertions;
using Xunit;
using Zartis.Rocket.Enums;
using Zartis.Rocket.UnitTests.Builders;
using Zartis.Rocket.UnitTests.Builders.Mocks;
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
                _position = new PositionBuilder().Build();

                var landingArea =
                    new LandingAreaMockBuilder()
                        .WithCheckPositionMocked(LandingAnswer, _position)
                        .Build();

                _sut =
                    new RocketBuilder()
                        .WithLandingArea(landingArea)
                        .Build();

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

        public abstract class Given_Two_Rockets_When_Asking_For_A_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Position _position;
            private LandingAnswers _result;
            private LandingAnswers _expectedResult;

            protected abstract LandingAnswers LandingAnswerForRocketOne { get; }
            protected abstract LandingAnswers LandingAnswerForRocketTwo { get; }

            protected override void Given()
            {
                _position = new PositionBuilder().Build();

                var landingAreaForRocketOne =
                    new LandingAreaMockBuilder()
                        .WithCheckPositionMocked(LandingAnswerForRocketOne, _position)
                        .Build();

                var rocketOne =
                    new RocketBuilder()
                        .WithLandingArea(landingAreaForRocketOne)
                        .Build();

                rocketOne.AskForPosition(_position);

                var landingAreaForRocketTwo =
                    new LandingAreaMockBuilder()
                        .WithCheckPositionMocked(LandingAnswerForRocketTwo, _position)
                        .Build();

                _sut =
                    new RocketBuilder()
                        .WithLandingArea(landingAreaForRocketTwo)
                        .Build();

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
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OkForLanding;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OkForLanding;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OkForLanding_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OkForLanding;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OutOfPlatform;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_OkForLanding
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.Clash;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.Clash;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_Clash_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.Clash;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OutOfPlatform;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_OkForLanding
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OutOfPlatform;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OkForLanding;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_Clash
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OutOfPlatform;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.Clash;
        }

        public class Given_Two_Rockets_When_The_RocketOne_Is_OutOfPlatform_For_A_Position_And_The_RocketTwo_Is_OutOfPlatform
            : Given_Two_Rockets_When_Asking_For_A_Position
        {
            protected override LandingAnswers LandingAnswerForRocketOne => LandingAnswers.OutOfPlatform;
            protected override LandingAnswers LandingAnswerForRocketTwo => LandingAnswers.OutOfPlatform;
        }
    }
}