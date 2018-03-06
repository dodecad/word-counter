using System;
using System.IO.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Core.Tests.ParallelWordCounterTests
{
    [TestClass]
    public class ParallelWordCounterTests_Constructor : ParallelWordCounterTests
    {
        private IFileSystem _fileSystemArgument;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenFileSystemArgumentIsNull_ExpectArgumentNullException()
        {
            // Arrange:
            this._fileSystemArgument = null;
            this.Stub();

            try
            {
                // Act:
                var result = this.Act();
            }
            catch (ArgumentNullException exception)
            {
                // Assert:
                Assert.AreEqual("fileSystem", exception.ParamName);
                this.AssertCore();
                throw;
            }
        }

        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            this._fileSystemArgument = this.FileSystem;
        }

        private ParallelWordCounter Act()
        {
            return new ParallelWordCounter(this._fileSystemArgument);
        }
    }
}
