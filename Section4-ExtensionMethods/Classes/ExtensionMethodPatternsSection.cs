using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section4_ExtensionMethods.Classes
{
    public class PatternsDemo
    {
        public static void Demo1()
        {
            
        }
    }
    public static class ExtensionMethodPatternsSection
    {
        //AppendLine().AppendLine()
        public static StringBuilder al(this StringBuilder sb,string text)
        {
            return sb.AppendLine(text);
        }
        //AppendFormatLine
        public static StringBuilder AppendFormatLine(this StringBuilder sb,string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        public static ushort XOR(this IList<ushort> values)
        {
            var first = values[0];
            foreach (var item in values)
            {
                first ^= item; 
            }
            return first;
        }
        public static void AddRange<T>(this IList<T> list,params T[] objects)
        {
            foreach (var item in objects)
            {
                list.AddRange(item);
            }
        }
        public static string f(this string format,params object[] args)
        {
            return string.Format(format, args);
        }
        public static DateTime June(this int dat,int year)
        {
            return new(year, 6, dat);
        }

    }
}
