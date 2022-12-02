using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    public class ConstructionSection
    {
        public static void ConstructionTests()
        {
            var t = typeof(bool);
            var b = Activator.CreateInstance(t);
            Actions.writeLine(b);
            var b2 = Activator.CreateInstance<bool>();
            Actions.writeLine(b2);

            var timer = Activator.CreateInstance("System","System.Timers.Timer");
            Actions.writeLine(timer?.Unwrap());//object handle

            var arrayListType = Type.GetType("System.Collections.ArrayList");
            Actions.writeLine(arrayListType);

            var ctor = arrayListType?.GetConstructor(Array.Empty<Type>());

            var al = ctor?.Invoke(Array.Empty<object>());

            var st = typeof(string);

            var Stringctor = st.GetConstructor(new[] { typeof(char[]) });

            var str = Stringctor?.Invoke(new object[]
            {
               new []{ 'c','a','g','r','i' }
            });
            Actions.writeLine(str);

            var listType = Type.GetType("System.Collections.Generic.List`1");
            Actions.writeLine(listType);
            var listOFInt = listType?.MakeGenericType(typeof(int));
            Actions.writeLine(listOFInt);

            var listOfIntCtor = listOFInt?.GetConstructor(Array.Empty<Type>());
            var instanceOfListOfInt = listOfIntCtor?.Invoke(Array.Empty<object>());

            Actions.writeLine(instanceOfListOfInt);

            var charType = typeof(char);
            var arrayInstance= Array.CreateInstance(charType,10);

            var charArrayType = charType?.MakeArrayType();
            Actions.writeLine(charArrayType);

            var charArrayConstructor = charArrayType?.GetConstructor(new[] { typeof(int) });
            Actions.writeLine(charArrayConstructor);
            var arr = charArrayConstructor?.Invoke(new object[] {20});
        }
    }
}
