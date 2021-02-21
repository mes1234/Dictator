using System;
using System.Collections.Generic;

namespace Dictator
{
    public class Parser : IParser
    {
        private IDictionary<string,object> _dictonaryToParse { get; set; }

        public IList<T> Parse<T>(IDictionary<string, object> dictonaryToParse) where T : new()
        {
            _dictonaryToParse = dictonaryToParse ?? throw new ArgumentNullException(nameof(dictonaryToParse));
            List<T> result = new List<T>();

            return result;

        }
    }
}
