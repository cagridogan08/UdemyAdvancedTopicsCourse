using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Section6_AssortedTopics.Classes
{
    internal class ContinuationPassingStyle
    {
        public enum WorkFlowResult
        {
            Success,Failure
        }
        public class QuadraticEquationSolver
        {
            /// <summary>
            /// ax^2+bx+c
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="c"></param>
            public WorkFlowResult Start(double a,double b,double c,out Tuple<Complex,Complex> result)
            {
                var disc = b * b - 4 * a * c;
                if (disc < 0)
                {
                    result = null;
                    return WorkFlowResult.Failure;
                }
                else
                {
                    return SolveSimple(a, b, c, disc,out result);
                }
            }

            private WorkFlowResult SolveSimple(double a, double b, double c, double disc,out Tuple<Complex,Complex> result)
            {
                var rootDisc = Math.Sqrt(disc);
                result= Tuple.Create(new Complex((-b+rootDisc)/2*a,0), new Complex((-b-rootDisc)/2*a,0));
                return WorkFlowResult.Success;
            }

            private Tuple<Complex,Complex> SolveComplex(double a, double b, double c,double disc)
            {
                var rootDisc = Complex.Sqrt(new Complex(disc, 0));
                return Tuple.Create((-b + rootDisc) / 2, (-b - rootDisc) / 2);
            }
        }
        public static void Demo()
        {
            var solver = new QuadraticEquationSolver();
            Tuple<Complex, Complex> solution;
            var flag = solver.Start(1, 10, 16, out solution);
            switch (flag)
            {
                case WorkFlowResult.Success:
                    Actions.writeLine(solution);
                    break;
                case WorkFlowResult.Failure:
                    break;
                default:
                    break;
            }
        }
    }
}
