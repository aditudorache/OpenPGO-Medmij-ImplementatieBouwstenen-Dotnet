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

    public class Whitelist
    {
        public static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        public static readonly XName WhitelistRoot = NS + "Whitelist";
        public static readonly XName MedMijNode = NS + "MedMijNode";

        private readonly HashSet<string> hosts;

        private Whitelist(XDocument doc)
        {
            Validate(doc);
            this.hosts = Parse(doc);
        }

        public static Whitelist FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Whitelist(doc);
        }

        public static async Task<Whitelist> FromURL(string url)
        {
            using (var c = new HttpClient())
            {
                var data = await c.GetStringAsync(url).ConfigureAwait(false);
                return FromXMLData(data);
            }
        }

        public bool Contains(string hostname) => this.hosts.Contains(hostname);

        private static void Validate(XDocument doc)
        {
            var schemas = new XmlSchemaSet();
            var assembly = typeof(Whitelist).Assembly;
            var resource = assembly.GetManifestResourceStream("MedMij.Whitelist.xsd");
            var schemareader = XmlReader.Create(resource);

            schemas.Add(NS.NamespaceName, schemareader);
            doc.Validate(schemas, (a, b) => throw b.Exception);

            var root = doc.Element(WhitelistRoot);
            if (root == null)
            {
                throw new XmlSchemaException($"Wrong root element: got {doc.Root.Name} expected {WhitelistRoot}");
            }
        }

        private static HashSet<string> Parse(XDocument doc)
            => new HashSet<string>(doc.Descendants(MedMijNode).Select(n => n.Value));
    }
}