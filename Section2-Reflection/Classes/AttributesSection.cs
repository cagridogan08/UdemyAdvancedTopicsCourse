using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    internal class AttributeSection:Attribute
    {

        public int Timer { get; private set; }
        public AttributeSection()
        {
            Timer++;
        }

        public AttributeSection(int v)
        {
            this.Timer = v;
        }

        public class TestClass
        {
            [AttributeSection(33)]
            public static void TestFunction1()
            {
                
            }
            public static void TestMainFunction()
            {
                var sm = typeof(TestClass).GetMethod("TestFunction1");

                foreach (var attr in sm.GetCustomAttributes(true))
                {
                    Actions.writeLine($"Attr : {attr.GetType()}");  
                    if(attr is AttributeSection at)
                    {
                        Actions.writeLine($"Repeat Time {at.Timer}");
                    }
                }
            }
        }
    }
}
