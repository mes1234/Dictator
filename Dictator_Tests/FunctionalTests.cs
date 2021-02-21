using System;
using Xunit;
using Dictator;
using System.Collections.Generic;

namespace Dictator_Tests
{
    public class FunctionalTests
    {
        class myInternalClass
        {
          public  int PropA { get; set; }
          public  int PropB { get; set; }
        }

        class myInternalClassFull : myInternalClass
        {
            public string Name { get; set; }
        }

        [Fact]
        public void CheckSimpleDictionary()
        {

            Dictionary<string, myInternalClassFull> testDict = new Dictionary<string, myInternalClassFull>()
            {
                { 
                    "item1" , new myInternalClassFull()
                    {
                        PropA =10,
                        PropB=11
                    }
                },
                { 
                    "item2" , new myInternalClassFull()
                    {
                        PropA =10,
                        PropB=11
                    }
                }
            };
            IList<myInternalClassFull> result= Parser<myInternalClassFull>.Parse(testDict);

            foreach(myInternalClassFull myInternal in result)
            {
                Assert.NotNull(myInternal.Name);
            }

        }
    }
}
