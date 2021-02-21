using System;
using System.Collections.Generic;
using System.Text;

namespace Dictator
{
    public interface IParser
    {
        // Parse givent dictionary to List of type T
        IList<T> Parse<T>(IDictionary<string,object> dictonaryToParse) where T : new();
    }
}
