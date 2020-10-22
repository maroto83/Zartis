using System;

namespace Zartis.Rocket.UnitTests.TestSupport
{
    public abstract class Given_When_Then_Test
        : IDisposable
    {
        protected Given_When_Then_Test()
        {
            Setup();
        }

        private void Setup()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract void When();

        public void Dispose()
        {
            Cleanup();
        }

        protected virtual void Cleanup()
        {
        }
    }
}
