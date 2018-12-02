// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

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
    using MedMij.Utils;

    /// <summary>
    /// Een whitelist zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Whitelist
    {
        private static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        private static readonly XName WhitelistRoot = NS + "Whitelist";
        private static readonly XName MedMijNode = NS + "MedMijNode";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource(Definitions.XsdName(Definitions.Whitelist), NS);

        private readonly List<string> data;

        private Whitelist(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, WhitelistRoot);
            this.data = Parse(doc);
        }

        public List<string> Data => data;

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
        /// Bepaalt of een <see cref="Whitelist"/> een bepaalde hostname bevat.
        /// </summary>
        /// <param name="hostname">De hostname die gecontroleerd wordt.</param>
        /// <returns><c>true</c> als de hostname op de lijst staat. Anders <c>false</c>.</returns>
        public bool Contains(string hostname) => this.data.Contains(hostname);

        private static List<string> Parse(XDocument doc)
            => doc.Descendants(MedMijNode).Select(n => n.Value).ToList();
    }
}
