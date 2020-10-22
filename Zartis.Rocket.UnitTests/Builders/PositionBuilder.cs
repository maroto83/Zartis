namespace Zartis.Rocket.UnitTests.Builders
{
    public class PositionBuilder
    {
        private int _x;
        private int _y;

        public PositionBuilder()
        {
            _x = 5;
            _y = 5;
        }

        public PositionBuilder WithX(int x)
        {
            _x = x;
            return this;
        }

        public PositionBuilder WithY(int y)
        {
            _y = y;
            return this;
        }

        public Position Build()
        {
            var position = new Position(_x, _y);

            return position;
        }
    }
}