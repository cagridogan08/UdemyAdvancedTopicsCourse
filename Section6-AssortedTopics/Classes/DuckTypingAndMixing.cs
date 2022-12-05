using Section2_Reflection.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section6_AssortedTopics.Classes
{
    internal class DuckTypingAndMixing
    {
        interface IMyDisposable<T>:IDisposable
        {
            void IDisposable.Dispose()
            {
                Actions.writeLine("Disposed Class");
            }
        }

        interface IScalar<T> : IEnumerable<T>
        {
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                yield return (T)this;
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class MyClass : IMyDisposable<MyClass>,IScalar<MyClass>
        {
            public override string ToString()
            {
                return "MyClass";
            }
        }
        ref struct Foo
        {
            public void Dispose()
            {
                Actions.writeLine("Foo Disposed");
            }
        }
        public static void Demo1()
        {
            using(var xx = new Foo())
            {

            }
            using(var mc = new MyClass())
            {
                foreach (var item in mc)
                {
                    Actions.writeLine(item);
                }
            }
        }
        
    }
}
