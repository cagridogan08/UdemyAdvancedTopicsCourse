using Section5_MemoryManagement.Classes;

internal class Program
{
    private static void Demo1()
    {
        InStatement.Demo1();
    }
    private static void Demo2()
    {
        SpanSection.Demo1();
    }
    private static void Main(string[] args)
    {
        //Demo1();
        Demo2();
        Console.WriteLine("Hello, World!");
    }
}