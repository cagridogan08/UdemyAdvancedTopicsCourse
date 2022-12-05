using Section6_AssortedTopics.Classes;

internal class Program
{
    private static void Demo1()
    {
        DisposableSection.Demo1();
    }
    private static void Demo2()
    {
        DuckTypingAndMixing.Demo1();
    }
    private static void Demo3()
    {
        ContinuationPassingStyle.Demo();
    }
    private static void Demo4()
    {
        DemoClass.Demo();
    }
    private static void Main(string[] args)
    {
        //Demo1();
        //Demo2();
        //Demo3();
        Demo4();
        //Console.WriteLine("Hello, World!");
    }
}