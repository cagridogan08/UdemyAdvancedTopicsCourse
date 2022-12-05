using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section6_AssortedTopics.Classes
{
    internal class DisposableSection 
    {
        private sealed class DisposableObject : IDisposable
        {
            public DisposableObject()
            {
                Actions.writeLine("Initialized");
            }

            public void Dispose()
            {
                Actions.writeLine("Disposed");
            }
        }
        private sealed class SimpleTimer : IDisposable
        {
            private readonly Stopwatch st;
            public SimpleTimer()
            {
                st = new();
                st.Start();
            }
            public void Dispose()
            {
                //Thread.Sleep(1000);

                st.Stop();
                Actions.writeLine($"Elapsed Time :{st.ElapsedMilliseconds}");
            }
        }
        private sealed class Disposable : IDisposable
        {
            private readonly Action end;
            private Disposable(Action start,Action end)
            {
                this.end = end;
                start();
            }
            public void Dispose()
            {
                end();
            }
            public static Disposable Create(Action start,Action end)
            {
                return new Disposable(start, end);
            }
        }
        public static void Demo1()
        {
            var item = new DisposableObject();

            item.Dispose();
            using(var mc = new DisposableObject())
            {

            }
            using(var bt = new SimpleTimer())
            {
                Thread.Sleep(1000);
            }
            var st = new Stopwatch();
            using (Disposable.Create(()=>st.Start(),
                ()=>st.Stop()))
            {
                Actions.writeLine($"Elapsed Time : {st.ElapsedMilliseconds}");
                Thread.Sleep(1000);
            }

        }
        
    }
}
