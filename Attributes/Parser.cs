using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public static class Parser
    {
        public static bool TryParse<T>(string value, out T result)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Static;
            var parameterTypes = new Type[] { typeof(string), typeof(T).MakeByRefType() };
            var tryParseMathod = typeof(T).GetMethod("TryParse", bindingFlags, null, parameterTypes, null);

            var parameters = new object[] { value, null };
            var isParsed = (bool)tryParseMathod?.Invoke(null, parameters);

            if (isParsed)
            {
                result = (T)parameters[1];
                return isParsed;
            }

            result = default;
            return false;
        }
    }
}
