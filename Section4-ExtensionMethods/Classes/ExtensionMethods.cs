using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Section4_ExtensionMethods.Classes
{
    public class DemoClass
    {
        public static void Demo1()
        {
            var item = new DefaultClass();
            item.TestFunc();
            Actions.writeLine(55.ToBinary());
            new ChildDefaultClass().TestFunc();

            Func<int> calculate = delegate
            {
                Thread.Sleep(1000);
                return 42;
            };
            Actions.writeLine(calculate.Measure().Elapsed.Milliseconds);

            "hello".Foo();
        }
    }
    public class DefaultClass
    {
        public virtual string Name => "Cagri";
    }
    public class ChildDefaultClass:DefaultClass
    {
        public override string Name => "DefaultChild";
    }
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public static class ExtensionMethods
    {
        public static void TestFunc(this DefaultClass def)
        {
            Actions.writeLine(def.Name);
        }
        public static void TestFunc(this ChildDefaultClass def)
        {
            Actions.writeLine(def.Name);
        }
        public static string ToBinary(this int val)
        {
            return Convert.ToString(val,2);
        }
        public static void Save(this ISerializable serializable)
        {

        }
        public static Person ToPerson(this (string name,int val) data)
        {
            return new Person(data.name, data.val);
        }
        public static int Measure<T,U>(this Tuple<T,U> t)
        {
            return t.Item2.ToString().Length;
        }
        public static Stopwatch Measure(this Func<int> f)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            f();
            sw.Start();
            return sw;
        }
        public static void Foo(this object o)
        {
            Actions.writeLine(o);
        }
        public static void DeepCopy<T>(this T o)where T: ISerializable,new()
        {
            
        }
    }
}
