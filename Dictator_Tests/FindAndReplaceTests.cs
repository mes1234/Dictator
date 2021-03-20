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
            var result = Parser.FindAndReplace<JsonDictClass, StronglyTypedObjects, ParsedJsonWithDict>(testDict);
      
            foreach(var item in result.items)
            {
                Assert.NotNull(item.GetType().GetProperty("Name").GetValue(item));
            }
        }

        [Theory]
        [ClassData(typeof(ParsedJsonDataTest))]
        public void CheckNestedDictionary(ParsedJsonWithDict testDict)
        {
            List<ParsedJsonWithDict> parsedJsonWithDicts = new List<ParsedJsonWithDict>()
            {
                testDict,
                testDict,
                testDict
            };


            var result = Parser.FindAndReplace<JsonDictClass, StronglyTypedObjects, List<ParsedJsonWithDict>>(parsedJsonWithDicts);
      
            foreach(var item in result)
            {
                Assert.NotNull(item.GetType().GetProperty("Name").GetValue(item));
            }
        }
    }
}
