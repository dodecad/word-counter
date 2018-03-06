using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Tests
{
    [TestClass]
    public abstract class UnitTestContainer
    {
        public virtual void TestInitialise()
        {
        }

        protected virtual void AssertCore()
        {
        }

        protected virtual void Stub()
        {
        }
    }
}
