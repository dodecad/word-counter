using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Core.Tests.ParallelWordCounterTests
{
    [TestClass]
    public class ParallelWordCounterTests_CountWords : ParallelWordCounterTests
    {
        private string _path;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountWords_WhenPathIsNull_ExpectArgumentNullException()
        {
            // Arrange:
            this._path = null;
            this.Stub();

            try
            {
                // Act:
                var result = this.Act();
            }
            catch (ArgumentNullException exception)
            {
                // Assert:
                Assert.AreEqual("path", exception.ParamName);
                this.AssertCore();
                throw;
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountWords_WhenPathIsEmpty_ExpectArgumentNullException()
        {
            // Arrange:
            this._path = string.Empty;
            this.Stub();

            try
            {
                // Act:
                var result = this.Act();
            }
            catch (ArgumentNullException exception)
            {
                // Assert:
                Assert.AreEqual("path", exception.ParamName);
                this.AssertCore();
                throw;
            }
        }

        [TestMethod, Ignore]
        public void CountWords_UnderValidCircumstances_ExpectSuccess()
        {
            // Arrange:
            this.FileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {
                    "/home/alex/Documents/test_source",
                    new MockFileData("early to bed, early to rise makes a man healthy, wealthy, and wise")
                }
            });

            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual["early"]);
            Assert.AreEqual(2, actual["to"]);
            Assert.AreEqual(1, actual["wise"]);
            this.AssertCore();
        }
        
        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();
        }

        private IDictionary<string, int> Act()
        {
            return this.ParallelWordCounter.CountWords(this._path);
        }
    }
}
