using Section2_Reflection.Classes;

internal class Program
{
    private static void Demo1()
    {
        SystemTypeSection.TypeTests();
    }
    private static void Demo2()
    {
        InspectionSection.InspectionTests();
    }
    private static void Demo3()=>ConstructionSection.ConstructionTests();
    private static void Main(string[] args)
    {
        //Demo1();
        //Demo2();
        Demo3();
        //Console.WriteLine("Hello, World!");
        //Console.ReadKey();
    }
}