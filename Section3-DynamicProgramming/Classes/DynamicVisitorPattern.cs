using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DynamicProgramming.Classes
{
    internal class DynamicVisitorPattern
    {
        public abstract class Expression
        {

        }
        public class Literal : Expression
        {
            public double Value { get; set; }

            public Literal(double value)
            {
                Value = value;
            }
        }
        public class Addition : Expression
        {
            public Expression Left { get; set; }
            public Expression Right { get; set; }

            public Addition(Expression left,Expression right)
            {
                Right = right;
                Left = left;
            }
        }
        public class ExpressionPrinter
        {
            public static void Print(Literal literal,StringBuilder builder)
            {
                builder.Append(literal.Value);
            }
            public static void Print(Addition e,StringBuilder sb)
            {
                sb.Append('(');
                Print((dynamic)e.Left, sb);
                sb.Append('+');
                Print((dynamic)e.Right, sb);
                sb.Append(')');
            }
        }

        public class DynamicVisitorDemo
        {
            public static void FirstFunction()
            {
                var e = new Addition(new Addition(new Literal(1), new Literal(2)),new Literal(3));

                var sb = new StringBuilder();
                ExpressionPrinter.Print((dynamic)e, sb);
                Actions.writeLine(sb);
            }
        }
    }
}
