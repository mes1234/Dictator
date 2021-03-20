using System;
using Xunit;
using Dictator;
using System.Collections.Generic;
using System.Collections;

namespace Dictator_Tests
{
    
    public class FindAndReplaceTests
    {

        [Theory]
        [ClassData(typeof(ParsedJsonDataTest))]
        public void CheckSimpleDictionary(ParsedJsonWithDict testDict)
        {
            var result = (ParsedJsonWithDict)Parser.FindAndReplace<JsonDictClass, StronglyTypedObjects, ParsedJsonWithDict>(testDict);
      
            foreach(var item in result.items)
            {
                Assert.NotNull(item.GetType().GetProperty("Name").GetValue(item));
            }
        }
        [Theory]
        [ClassData(typeof(NestedParsedJsonDataTest))]
        public void CheckNestedDictionary(ParsedJsonWithDict testDict)
        {
            var result = (ParsedJsonWithDict)Parser.FindAndReplace<JsonDictClass, StronglyTypedObjects, ParsedJsonWithDict>(testDict);
      
            foreach(var item in result.items)
            {
                Assert.NotNull(item.GetType().GetProperty("Name").GetValue(item));
            }
        }
    }
}
