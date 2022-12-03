using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DynamicProgramming.Classes
{
    internal class DynamicSection
    {
        public static void FirstFunction()
        {
            // late binding
            dynamic d = "cagri";
            Actions.writeLine(d.GetType());
            Actions.writeLine(d.Length);

            d = 125;
            Actions.writeLine(d.GetType());

            var k = new DynamicClass() as dynamic;
            Actions.writeLine(k.Name);

            Actions.writeLine(k[7]);

            k.WhatIsThis();
        }
        public class DynamicClass : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object? result)
            {
                result = binder.Name;
                return true;
            }
            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
            {
                if(indexes.Length == 1)
                {
                    result = new string('-', (int)indexes[0]);
                    return true;
                }
                result = null;
                return false;
            }
            public dynamic This => this;
            public void WhatIsThis()
            {
                Actions.writeLine(This.TestProp);
            }
        }
    }
}
