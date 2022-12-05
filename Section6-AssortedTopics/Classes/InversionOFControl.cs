using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Section6_AssortedTopics.Classes
{
    public static class InversionOFControl
    {
        public struct BoolMarker<T>
        {
            public bool Result;
            public T self;
            public enum Operation
            {
                None,
                And,
                Or
            }
            internal Operation PendingOp;

            internal BoolMarker(bool result, T self, BoolMarker<T>.Operation pendingOp)
            {
                Result = result;
                this.self = self;
                PendingOp = pendingOp;
            }
            public BoolMarker(bool result, T self) : this(result, self, Operation.None) { }
            public BoolMarker<T> And=>new BoolMarker<T>(Result,self, Operation.And);
            public static implicit operator bool(BoolMarker<T> marker)
            {
                return marker.Result;
            }
        }

        public static T AddTo<T>(this T self, ICollection<T>[] collection)
        {
            foreach (var item in collection)
            {
                item.Add(self);
            }
            return self;
        }
        public static bool IsOneOF<T>(this T self,params T[] values)
        {
            return values.Contains(self);
        }
        public static bool HasNo<TSubject,T>(this TSubject self,Func<TSubject,IEnumerable<T>> props)
        {
            return !props(self).Any();
        }
        public static bool HasSome<TSubject,T>(this TSubject self,Func<TSubject,IEnumerable<T>> props)
        {
            return props(self).Any();
        }
        public static BoolMarker<TSubject> HasNo2<TSubject,T>(this TSubject self, 
            Func<TSubject, IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(!props(self).Any(),self);
        }
        public static BoolMarker<TSubject> HaveSome2<TSubject,T>(this TSubject self,
            Func<TSubject,IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(HasSome(self,props),self);
        }
    }
    public class Person
    {
        public List<string> Names = new();
        public List<Person> Children = new();
    }
    public class DemoClass
    {
        public static void Demo()
        {
            var list = new List<int>();
            var list2 = new List<int>();
            24.AddTo(new[] {list,list2});//.AddTo(list2);
        }
        public void ProcessCommand(string code)
        {
            //if (new[] { "AND", "OR", "XOR" }.Contains(code))
            //{

            //}
            if (code.IsOneOF("AND", "OR", "XOR"))
            {

            }
        }
        public void ProcessPerson(Person person)
        {
            if (person.HasNo(e => e.Names))//Has No Names
            {

            }
        }
    }
}
