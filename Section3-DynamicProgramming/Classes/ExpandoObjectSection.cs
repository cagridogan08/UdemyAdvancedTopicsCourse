using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DynamicProgramming.Classes
{
    internal class ExpandoObjectSection
    {
        public static void Demo1()
        {
            var person = new ExpandoObject() as dynamic;
            person.FirstName = "Cagri";
            person.Age = 26;

            Actions.writeLine($"Name:{person.FirstName} {person.Age} years old");

            person.Address = new ExpandoObject();
            person.Address.City = "Eskisehir";
            person.Address.Country = "Turkey";

            person.WriteAddressInformation = new Action(() =>
            {
                Actions.writeLine($"City : {person.Address.City} - Country = {person.Address.Country}");
            });
            person.WriteAddressInformation();

            /*Event*/
            person.FallsIll = null;

            person.FallsIll += new EventHandler<dynamic>((sender, args) =>
            {
                Actions.writeLine(args);
            });
            EventHandler<dynamic> e = person.FallsIll;

            e.Invoke(person, person.FirstName);


            var dict = (IDictionary<string, object>)person;
            Actions.writeLine(dict.ContainsKey("FirstName"));
            Actions.writeLine(dict.ContainsKey("LastName"));

            dict["LastName"] = "Dogan";
            if (dict.TryGetValue("LastName", out object val))
                Actions.writeLine(person.LastName);

        }
    }
}
