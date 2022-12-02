using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    public class InspectionSection
    {
        
        public static void InspectionTests()
        {
            var t = typeof(Guid);
            Actions.writeLine(t.Name);

            var cTors = t.GetConstructors();
            foreach (var item in cTors)
            {
                Actions.write("- Guid(");
                var pars = item.GetParameters();
                foreach (var param in pars)
                {
                    Actions.write($"{param.ParameterType.Name} {param.Name},");
                }
                Actions.writeLine(")");
                Actions.writeLine(item.ToString());
            }
            var methods = t.GetMethods();
            Actions.writeLine("<------Methods------>");
            foreach (var item in methods)
            {
                Actions.writeLine(item.Name);
                foreach (var param in item.GetParameters())
                {
                    Actions.write($"({param.ParameterType})");
                }
            }
            Actions.writeLine("<------Events------>");
            foreach (var item in t.GetEvents())
            {
                Actions.writeLine(item.Name);
            }
        }
    }
}
