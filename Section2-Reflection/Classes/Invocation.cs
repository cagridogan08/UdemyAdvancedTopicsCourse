using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Section2_Reflection.Classes
{
    internal class Invocation
    {
        public static void FirstFuncq()
        {
            var s = "test";
            var t = typeof(string);
            var trimMethod = t.GetMethod("Trim",Array.Empty<Type>());
            Actions.writeLine(trimMethod);

            var result = trimMethod?.Invoke(s,Array.Empty<object>());

            Actions.writeLine(result);

            var charTrim = t.GetMethod("Trim", new[] { typeof(char[]) });

            Actions.writeLine(charTrim);

            var resultAfterCharTrim = charTrim?.Invoke(s, new[] { new[] { 't'} });

            Actions.writeLine(resultAfterCharTrim);

            var numberString = "123";
            var parseMethod = typeof(int).GetMethod("TryParse", new[] { typeof(string), typeof(int).MakeByRefType() });

            object[] args = { numberString, null };//
            var number = parseMethod?.Invoke(null, args);

            Actions.writeLine(args[1]);

            var at = typeof(Activator);

            var method = at.GetMethod("CreateInstance", Array.Empty<Type>());

            Actions.writeLine(method);

            var ciGeneric = method?.MakeGenericMethod(typeof(Guid));//set type of T

            Actions.writeLine(ciGeneric);

            var tt = ciGeneric?.Invoke(null, Array.Empty<object>());

            Actions.writeLine(tt);
        }
    }
}
