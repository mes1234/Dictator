using System;
using System.Collections.Generic;

namespace Dictator
{
    public static class Parser
    {
        public static ICollection<U> Parse<T,U>(IDictionary<string, T> dictonaryToParse) 
            where T : class, new() // Source Type
            where U : class, new() // Destination Type
        {
            if (dictonaryToParse is null)
            {
                throw new ArgumentNullException(nameof(dictonaryToParse));
            }

            ICollection<U> result = new List<U>();

            foreach (KeyValuePair<string,T> item in dictonaryToParse)
            {
                U mappedItem = new U();
                var props = item.Value.GetType().GetProperties();
                foreach(var prop in props)
                {
                    try
                    {
                        var value = item.Value
                            .GetType()
                            .GetProperty(prop.Name)
                            .GetValue(item.Value);

                        mappedItem
                            .GetType()
                            .GetProperty(prop.Name)
                            .SetValue(mappedItem, value);
                    }
                    catch
                    {
                        continue;
                    }
                }
                try
                {
                    mappedItem
                        .GetType()
                        .GetProperty("Name")
                        .SetValue(mappedItem, item.Key);
                }
                catch
                {
                    throw;
                }

                result.Add(mappedItem);       
            } 
            return result;
        }

        /// <summary>
        /// Find in object all 
        /// </summary>
        /// <typeparam name="T">Source</typeparam>
        /// <typeparam name="U">Destination</typeparam>
        /// <typeparam name="V">External</typeparam>
        /// <param name="objectToCorrect"></param>
        /// <returns></returns>
        public static V FindAndReplace<T,U,V>(V objectToCorrect)
            where T : class, new() // Source Type
            where U : class, new() // Destination Type
            where V : class, new() // External Type
        {
            if (objectToCorrect is null)
            {
                throw new ArgumentNullException(nameof(objectToCorrect));
            }

            IEnumerable<object> indexable = objectToCorrect as IEnumerable<object>;
            if (indexable != null)
            {
                foreach(var item in indexable)
                {
                    FindAndReplace<T, U, object>(item);
                }
                return objectToCorrect;
            }


            var props = objectToCorrect.GetType().GetProperties();

            foreach (var prop in props)
            {
                Dictionary<string, T> propToChange = objectToCorrect
                    .GetType()
                    .GetProperty(prop.Name)
                    .GetValue(objectToCorrect) as Dictionary<string, T>;
                if (propToChange != null)
                {
                    IDictionary<string, T> dictToPars = (IDictionary<string, T>)propToChange;
                    List<U> correctedProp = (List<U>)Parse<T, U>(dictToPars);
                    objectToCorrect
                        .GetType()
                        .GetProperty(prop.Name)
                        .SetValue(objectToCorrect, correctedProp);
                }
            }

            return objectToCorrect;
        }
    }
}
