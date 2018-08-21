// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    /// <summary>
    /// Een zorgaanbiederslijst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class ZorgaanbiedersCollection : IEnumerable<Zorgaanbieder>
    {
        private static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/";
        private static readonly XName ZorgaanbiederslijstRoot = NS + "Zorgaanbiederslijst";
        private static readonly XName ZorgaanbiederName = NS + "Zorgaanbieder";
        private static readonly XName ZorgaanbiedernaamName = NS + "Zorgaanbiedernaam";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("Zorgaanbiederslijst.xsd", NS);

        private readonly IReadOnlyDictionary<string, Zorgaanbieder> dict;

        private ZorgaanbiedersCollection(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, ZorgaanbiederslijstRoot);
            this.dict = Parse(doc);
        }

        /// <summary>
        /// Initialiseert een <see cref="ZorgaanbiedersCollection"/> vanuit een string. Parset de string and valideert deze.
        /// </summary>
        /// <param name="xmlData">Een string met de zorgaanbiederslijst als XML.</param>
        /// <returns>De nieuwe <see cref="ZorgaanbiedersCollection"/>.</returns>
        public static ZorgaanbiedersCollection FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new ZorgaanbiedersCollection(doc);
        }

        /// <summary>
        /// Initialiseert een <see cref="ZorgaanbiedersCollection"/> vanuit een URL. Downloadt de lijst, parset en valideert deze.
        /// </summary>
        /// <param name="url">Een URL waar de lijst kan worden gedownloadet.</param>
        /// <param name="httpClientFactory">De context voor de download</param>
        /// <param name="cancellationToken">Een cancellationtoken kan gebruikt worden om een cancellation door te geven.</param>
        /// <returns>De nieuwe <see cref="ZorgaanbiedersCollection"/>.</returns>
        public static async Task<ZorgaanbiedersCollection> FromURLAsync(Uri url, System.Net.Http.IHttpClientFactory httpClientFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            string data;
            using (var c = httpClientFactory.CreateClient())
            {
                data = await c.GetStringAsync(url, cancellationToken).ConfigureAwait(false);
            }

            return FromXMLData(data);
        }

        /// <summary>
        /// Geeft de <see cref="Zorgaanbieder"/> met de opgegeven naam.
        /// </summary>
        /// <param name="name">De naam van de <see cref="Zorgaanbieder"/></param>
        /// <returns>De gezochte <see cref="Zorgaanbieder"/>.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Wordt gegenereerd als de naam niet wordt gevonden.</exception>
        public Zorgaanbieder GetByName(string name) => this.dict[name];

        /// <summary>
        /// Returnt een enumerator die door de <see cref="Zorgaanbieder"/>s itereert.
        /// </summary>
        /// <returns>De <see cref="IEnumerator"/>.</returns>
        IEnumerator<Zorgaanbieder> IEnumerable<Zorgaanbieder>.GetEnumerator() => this.dict.Values.GetEnumerator();

        /// <summary>
        /// Returnt een enumerator die door de <see cref="Zorgaanbieder"/>s itereert.
        /// </summary>
        /// <returns>De <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.dict.Values.GetEnumerator();

        private static IReadOnlyDictionary<string, Zorgaanbieder> Parse(XDocument doc)
        {
            Zorgaanbieder ParseZorgaanbieder(XElement x)
                => new Zorgaanbieder(naam: x.Element(ZorgaanbiedernaamName).Value);

            var zorgaanbieders = doc.Descendants(ZorgaanbiederName).Select(ParseZorgaanbieder);
            var d = zorgaanbieders.ToDictionary(z => z.Naam, z => z);
            return new ReadOnlyDictionary<string, Zorgaanbieder>(d);
        }
    }
}
