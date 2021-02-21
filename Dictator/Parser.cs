using System;
using System.Collections.Generic;

namespace Dictator
{
    public static class Parser<T> where T : class, new()
    {

        public static IList<T> Parse(Dictionary<string, T> dictonaryToParse) 
        {
            if (dictonaryToParse is null)
            {
                throw new ArgumentNullException(nameof(dictonaryToParse));
            }

            IList<T> result = new List<T>();

            foreach (KeyValuePair<string,T> instance in dictonaryToParse)
            {

                instance
                    .Value
                    .GetType()
                    .GetProperty("Name") //TODO this should be some Attribute
                    .SetValue(instance.Value, instance.Key);
                result.Add(instance.Value);
            }

            
            return result;

        }
    }
}
