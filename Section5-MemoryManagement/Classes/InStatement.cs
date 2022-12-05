using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section5_MemoryManagement.Classes
{
    public class InStatement
    {
        private class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point()
            {
            }
            private static Point origin = new();
            public static ref readonly Point Origin
            {
                get => ref origin;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"{X},{Y}";
            }
        }
        static double MeasureDistance(in/*readonly ref struct keyword*/ Point p1,in Point p2)
        {
            /*values turns readonly*/
            //ChangeMe(ref p2);
            /*Cannot overload*/
            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return Math.Sqrt(dx*dx+dy*dy);
        }

        private static void ChangeMe(ref Point p2)
        {
            p2.X++;
        }

        public static void Demo1()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(4, 5);

            Actions.writeLine($"Measure between {p1} and {p2} is {MeasureDistance(p1, p2)}");
            var distanceFromOriging = MeasureDistance(p1, Point.Origin);

            ref readonly var oo = ref Point.Origin;
            oo.X++;
        }
    }
}
