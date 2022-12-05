using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section4_ExtensionMethods.Classes
{
    public class DemoClassValueTuples
    {
        public static void Demo1()
        {
            Actions.writeLine((3, 2,2005).dmy());
            var firstList = new List<int>() { 1, 2, 3 };
            var secondList = new List<int>() { 8,6,4 };
            var tt = (firstList, secondList).Merge();
            foreach (var item in tt)
            {
                Actions.write($"{item}-");
            }
        }
    }
    public static class MethodsOnValueTuples
    {
        public static DateTime dmy(this (int day,int month,int year) date)
        {
            Actions.writeLine($"Day :{date.day} Month:{date.month} Year : {date.year}");
            return new DateTime(date.year, date.month, date.day);
        }
        public static List<T> Merge<T>(this (IList<T> First,IList<T> second) lists)
        {
            var result = new List<T>();
            result.AddRange(lists.First);
            result.AddRange(lists.second);
            return result;
        }
    }
}
