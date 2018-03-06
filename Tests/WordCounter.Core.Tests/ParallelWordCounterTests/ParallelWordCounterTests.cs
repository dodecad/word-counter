using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using WordCounter.Core.Contracts;
using WordCounter.Tests;

namespace WordCounter.Core.Tests.ParallelWordCounterTests
{
    public abstract class ParallelWordCounterTests : UnitTestContainer
    {
        public ParallelWordCounterTests()
        {
            this.FileSystem = new MockFileSystem();
            this.ParallelWordCounter = new ParallelWordCounter(this.FileSystem);
        }

        protected IFileSystem FileSystem { get; set; }

        protected IWordCounter ParallelWordCounter { get; set; }
    }
}
