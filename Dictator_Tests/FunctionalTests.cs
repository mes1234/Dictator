using System;
using Xunit;
using Dictator;
using System.Collections.Generic;
using System.Collections;

namespace Dictator_Tests
{
    

    public class FunctionalTests
    {
        
        [Theory]
        [ClassData(typeof(PropClassDataTest))]
        public void CheckSimpleDictionary(Dictionary<string, JsonDictClass> testDict)
        {
            var result= Parser.Parse<JsonDictClass, StronglyTypedObjects>(testDict);

            foreach(StronglyTypedObjects myInternal in result)
            {
                Assert.NotNull(myInternal.Name);
            }
        }       
        
        [Theory]
        [ClassData(typeof(PropClassDataTest))]
        public void CheckSimpleDictionaryWithNotCompliantDestClass(Dictionary<string, JsonDictClass> testDict)
        {
            var result= Parser.Parse<JsonDictClass, StonglyTypedObjectNotCompliant>(testDict);

            foreach(StonglyTypedObjectNotCompliant myInternal in result)
            {
                Assert.NotNull(myInternal.Name);
            }
        }
    }
}
