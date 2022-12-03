using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Section3_DynamicProgramming.Classes
{
    internal class DynamicXMLParsingSection
    {
        public static void Demo1()
        {
            var xml = @"<people><person name='Cagri'/></people>";

            var item = XElement.Parse(xml);

            var name = item.Element("person").Attribute("name");

            Actions.writeLine(name);

            var  dyn = new DynamicXML(item) as dynamic;
            Actions.writeLine(dyn.person.name);
        }
    }
    public class DynamicXML : DynamicObject
    {
        private XElement node;

        public DynamicXML(XElement node) => this.node = node;
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            var element = node.Element(binder.Name);
            if(element is not null)
            {
                result = new DynamicXML(element);
                return true;
            }
            else
            {
                var attribute = node.Attribute(binder.Name);
                if(attribute is not null)
                {
                    result = attribute.Value;
                    return true;
                }
                result = null;
                return false;
            }
            
        }
    }
}
