using Section4_ExtensionMethods.Classes;

internal class Program
{
    private static void Demo1()
    {
        DemoClass.Demo1();
    }
    private static void Demo2()
    {
        DemoClassValueTuples.Demo1();
    }
    private static void Demo3()
    {
        PersistenceDemo.Demo1();
    }
    private static void Demo4()
    {
        PatternsDemo.Demo1();
    }
    private static void Main(string[] args)
    {
        //Demo1();
        //Demo2();
        //Demo3();
        Console.WriteLine("Hello, World!");
    }
}