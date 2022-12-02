using Section1_Numerics.Classess;
using System;
internal class Program
{
    public static Action<string> Write = Console.WriteLine;
    private static void Demo1()
    {
        IntegralTypes.First();
        Console.ReadKey();
    }
    private static void Main(string[] args)
    {
        Demo1();
        //Console.WriteLine("Hello, World!");
    }
}