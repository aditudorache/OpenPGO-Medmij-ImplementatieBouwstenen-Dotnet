// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    /// <summary>
    /// Een whitelist zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Whitelist
    {
        private static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        private static readonly XName WhitelistRoot = NS + "Whitelist";
        private static readonly XName MedMijNode = NS + "MedMijNode";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("Whitelist.xsd", NS);

        private readonly HashSet<string> hosts;

        private Whitelist(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, WhitelistRoot);
            this.hosts = Parse(doc);
        }

        /// <summary>
        /// Initialiseert een <see cref="Whitelist"/> vanuit een string. Parset de string and valideert deze.
        /// </summary>
        /// <param name="xmlData">Een string met de whitelist als XML.</param>
        /// <returns>De nieuwe <see cref="Whitelist"/>.</returns>
        public static Whitelist FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Whitelist(doc);
        }

        /// <summary>
        /// Initialiseert een <see cref="Whitelist"/> vanuit een URL. Downloadt de lijst, parset en valideert deze.
        /// </summary>
        /// <param name="url">Een URL waar de lijst kan worden gedownloadet.</param>
        /// <param name="httpClientFactory">De context voor de download</param>
        /// <param name="cancellationToken">Een cancellationtoken kan gebruikt worden om een cancellation door te geven.</param>
        /// <returns>De nieuwe <see cref="Whitelist"/>.</returns>
        public static async Task<Whitelist> FromURL(Uri url, System.Net.Http.IHttpClientFactory httpClientFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            string data;
            using (var c = httpClientFactory.CreateClient())
            {
                data = await c.GetStringAsync(url, cancellationToken).ConfigureAwait(false);
            }

            return FromXMLData(data);
        }

        /// <summary>
        /// Bepaalt of een <see cref="Whitelist"/> een bepaalde hostname bevat.
        /// </summary>
        /// <param name="hostname">De hostname die gecontroleerd wordt.</param>
        /// <returns><c>true</c> als de hostname op de lijst staat. Anders <c>false</c>.</returns>
        public bool Contains(string hostname) => this.hosts.Contains(hostname);

        private static HashSet<string> Parse(XDocument doc)
            => new HashSet<string>(doc.Descendants(MedMijNode).Select(n => n.Value));
    }
}
