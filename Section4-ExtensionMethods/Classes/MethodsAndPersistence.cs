using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section4_ExtensionMethods.Classes
{
    public class PersistenceDemo
    {
        public static void Demo1()
        {
            var s = "Test String";
            s.SetTag(42);
            Actions.writeLine(s.GetTag());
        }
    }
    public static class MethodsAndPersistence
    {
        /*DateTests*/
        private static Dictionary<WeakReference, object> data = new();

        public static object GetTag(this object o)
        {
            var key = data.Keys.FirstOrDefault(k=>k.IsAlive&& k.Target == o);
            return key != null ? data[key] : null;
        }
        public static void SetTag(this object o,object tag)
        {
            var key = data.Keys.FirstOrDefault(k => k.IsAlive && k.Target == o);
            if(key is not null)
            {
                data[key] = tag;
            }
            else
            {
                data.Add(new WeakReference(o), tag);
            }
        }
    }
}
