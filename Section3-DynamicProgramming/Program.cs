using Section3_DynamicProgramming.Classes;

internal class Program
{
    private static void Demo1()
    {
        DynamicSection.FirstFunction();
    }
    private static void Demo2()
    {
        DynamicXMLParsingSection.Demo1();
    }
    private static void Demo3()
    {
        ExpandoObjectSection.Demo1();
    }
    private static void Main(string[] args)
    {
        //Demo1();
        //Demo2();
        Demo3();
        //Console.WriteLine("Hello, World!");
    }
}