//  Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class WhiteList
    {
        public static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        public static readonly XName WhiteListRoot = NS + "Whitelist";
        public static readonly XName MedMijNode = NS + "MedMijNode";

        private readonly HashSet<string> hosts;

        private WhiteList(XDocument doc)
        {
            Validate(doc);
            this.hosts = Parse(doc);
        }

        public static WhiteList FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new WhiteList(doc);
        }

        public static async Task<WhiteList> FromURL(string url)
        {
            using (var c = new HttpClient())
            {
                var data = await c.GetStringAsync(url);
                return FromXMLData(data);
            }
        }

        public bool Contains(string hostname) => this.hosts.Contains(hostname);

        private static void Validate(XDocument doc)
        {
            var schemas = new XmlSchemaSet();
            var assembly = typeof(WhiteList).Assembly;
            var resource = assembly.GetManifestResourceStream("MedMij.Whitelist.xsd");
            var schemareader = XmlReader.Create(resource);

            schemas.Add(NS.NamespaceName, schemareader);
            doc.Validate(schemas, (a, b) => throw b.Exception);

            var root = doc.Element(WhiteListRoot);
            if (root == null)
            {
                throw new XmlSchemaException($"Wrong root element: got {doc.Root.Name} expected {WhiteListRoot}");
            }
        }

        private static HashSet<string> Parse(XDocument doc)
            => new HashSet<string>(doc.Descendants(MedMijNode).Select(n => n.Value));
    }
}