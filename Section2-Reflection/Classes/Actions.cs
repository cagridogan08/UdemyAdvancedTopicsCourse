using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    public class Actions
    {
        public static Action<object?> writeLine = Console.WriteLine;
        public static Action<object?> write = Console.Write;
    }
}
