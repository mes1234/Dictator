using System;
using Xunit;
using Dictator;
using System.Collections.Generic;
using System.Collections;

namespace Dictator_Tests
{
    public class JsonDictClass
    {
        public int PropA { get; set; }
        public int PropB { get; set; }
    }

    public class StronglyTypedObjects : JsonDictClass
    {
        public string Name { get; set; }
    }

    public class StonglyTypedObjectNotCompliant
    {
        public string Name { get; set; }
        public int PropA { get; set; }
    }


    public class PropClassDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Dictionary<string, JsonDictClass>()
                {
                    {
                        "item1" , new JsonDictClass()
                        {
                            PropA = 10,
                            PropB = 11
                        }
                    },
                    {
                        "item2" , new JsonDictClass()
                        {
                            PropA = 10,
                            PropB = 11
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ParsedJsonWithDict
    {
       public ICollection items { get; set; }
    }


    public class ParsedJsonDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ParsedJsonWithDict()
                {
                    items = new Dictionary<string, JsonDictClass>()
                    {
                        {
                            "item1" , new JsonDictClass()
                            {
                                PropA = 10,
                                PropB = 11
                            }
                        },
                        {
                            "item2" , new JsonDictClass()
                            {
                                PropA = 10,
                                PropB = 11
                            }
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
