// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

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
    using MedMij.Utils;

    /// <summary>
    /// Een OAuth client list zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class OAuthClientCollection : IEnumerable<OAuthClient>
    {
        private static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/";
        private static readonly XName OAuthclientlistRoot = NS + "OAuthclientlist";
        private static readonly XName OAuthclientName = NS + "OAuthclient";
        private static readonly XName OrganisatienaamName = NS + "OAuthclientOrganisatienaam";
        private static readonly XName HostnameName = NS + "Hostname";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("OAuthclientlist.xsd", NS);

        private readonly IReadOnlyDictionary<string, OAuthClient> dict;

        private OAuthClientCollection(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, OAuthclientlistRoot);
            this.dict = Parse(doc);
        }

        /// <summary>
        /// Initialiseert een <see cref="OAuthClientCollection"/> vanuit een string. Parset de string and valideert deze.
        /// </summary>
        /// <param name="xmlData">Een string met de zorgaanbiederslijst als XML.</param>
        /// <returns>De nieuwe <see cref="OAuthClientCollection"/>.</returns>
        public static OAuthClientCollection FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new OAuthClientCollection(doc);
        }

        /// <summary>
        /// Geeft de <see cref="OAuthClient"/> met de opgegeven organisatienaam.
        /// </summary>
        /// <param name="naam">De organisatienaam van de <see cref="OAuthClient"/></param>
        /// <returns>De gezochte <see cref="OAuthClient"/>.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Wordt gegenereerd als de naam niet wordt gevonden.</exception>
        public OAuthClient GetByOrganisatienaam(string naam) => this.dict[naam];

        /// <summary>
        /// Returnt een enumerator die door de <see cref="OAuthClient"/>s itereert.
        /// </summary>
        /// <returns>De <see cref="IEnumerator"/>.</returns>
        IEnumerator<OAuthClient> IEnumerable<OAuthClient>.GetEnumerator() => this.dict.Values.GetEnumerator();

        /// <summary>
        /// Returnt een enumerator die door de <see cref="OAuthClient"/>s itereert.
        /// </summary>
        /// <returns>De <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.dict.Values.GetEnumerator();

        private static IReadOnlyDictionary<string, OAuthClient> Parse(XDocument doc)
        {
            OAuthClient ParseOAuthclient(XElement x)
                => new OAuthClient(
                    organisatienaam: x.Element(OrganisatienaamName).Value,
                    hostname: x.Element(HostnameName).Value);

            var oauthclients = doc.Descendants(OAuthclientName).Select(ParseOAuthclient);
            var d = oauthclients.ToDictionary(z => z.Organisatienaam, z => z);
            return new ReadOnlyDictionary<string, OAuthClient>(d);
        }
    }
}
