using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MedMij {
    public class WhiteList
    {
        public static readonly XNamespace ns = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        public WhiteList(XDocument doc)
        {
            var schemas = new XmlSchemaSet();
            var assembly = typeof(WhiteList).Assembly;
            var resource = assembly.GetManifestResourceStream("MedMij.Whitelist.xsd");            
            var schemareader = XmlReader.Create(resource);
            // var schema = XmlSchema.Read(resource, null);
            
            schemas.Add(ns.NamespaceName, schemareader);
            doc.Validate(
                schemas, 
                (a, b) => throw new Exception("WTFBBQ!"),
                true
            );

            var root = doc.Element(ns + "Whitelist");
            if (root == null)
                throw new Exception("huh?");
        }

        public static object FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new WhiteList(doc);
        }
    }
}