using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    public class SystemTypeSection
    {
        public static Action<string?> writeAction = Console.WriteLine;
        public static void TypeTests()
        {
            Type t = typeof(int);
            writeAction(t.Name);
            var methods = t.GetMethods();/*Contains information for collection of methods*/
            var t2 = "hello".GetType();
            writeAction(t2.FullName);
            foreach (var item in t2.GetFields())
            {
                writeAction(item.Name);
            }
            var a = typeof(string).Assembly;
            writeAction(a.FullName);
            var AssemblyTypes = a.GetTypes();
            //foreach (var item in a.GetTypes())
            //{
            //    writeAction(item.Name);
            //}
            var stringType = Type.GetType("System.String");
            /*GenericType For List '1 For Dict '2 */
            var tList = new List<string>().GetType();/*->System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]*/
            var listType = Type.GetType("System.Collections.Generin.List'1 [[System.String]]");
        }
    }
}
