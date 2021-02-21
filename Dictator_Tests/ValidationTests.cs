using System;
using Xunit;
using Dictator;
using System.Collections.Generic;

namespace Dictator_Tests
{
    public class ValidationTests
    {
        [Fact]
        public void CheckNullDictThrows()
        {
            Parser parser = new Parser();
            Assert.Throws<ArgumentNullException>(() => parser.Parse<object>(null));
        }
    }
}
