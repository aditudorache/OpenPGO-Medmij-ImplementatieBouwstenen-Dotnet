// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class Whitelist
    {
        public static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        public static readonly XName WhitelistRoot = NS + "Whitelist";
        public static readonly XName MedMijNode = NS + "MedMijNode";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("Whitelist.xsd", NS);

        private readonly HashSet<string> hosts;

        private Whitelist(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, WhitelistRoot);
            this.hosts = Parse(doc);
        }

        public static Whitelist FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Whitelist(doc);
        }

        public static async Task<Whitelist> FromURL(string url, System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            using (var c = httpClientFactory.CreateClient())
            {
                var data = await c.GetStringAsync(url).ConfigureAwait(false);
                return FromXMLData(data);
            }
        }

        public bool Contains(string hostname) => this.hosts.Contains(hostname);

        private static HashSet<string> Parse(XDocument doc)
            => new HashSet<string>(doc.Descendants(MedMijNode).Select(n => n.Value));
    }
}
