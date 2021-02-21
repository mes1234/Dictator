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
            Assert.Throws<ArgumentNullException>(() => Parser<object>.Parse(null));
        }
    }
}
