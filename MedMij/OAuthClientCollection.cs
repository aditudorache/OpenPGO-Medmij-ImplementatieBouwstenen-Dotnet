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
    public class OAuthClientCollection
    {
        private static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/";
        private static readonly XName OAuthclientlistRoot = NS + "OAuthclientlist";
        private static readonly XName OAuthclientName = NS + "OAuthclient";
        private static readonly XName OrganisatienaamName = NS + "OAuthclientOrganisatienaam";
        private static readonly XName HostnameName = NS + "Hostname";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("OAuthclientlist.xsd", NS);

        private readonly List<OAuthClient> data;

        private OAuthClientCollection(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, OAuthclientlistRoot);
            this.data = Parse(doc);
        }

        public List<OAuthClient> Data => data;

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
        public OAuthClient GetByOrganisatienaam(string naam)
        {
            var oauthClient = this.data.FirstOrDefault(p => p.Organisatienaam == naam);
            if (oauthClient == null)
                throw new KeyNotFoundException();

            return oauthClient;
        }

        private static List<OAuthClient> Parse(XDocument doc)
        {
            OAuthClient ParseOAuthclient(XElement x)
                => new OAuthClient(
                    organisatienaam: x.Element(OrganisatienaamName).Value,
                    hostname: x.Element(HostnameName).Value);

            var oauthclients = doc.Descendants(OAuthclientName).Select(ParseOAuthclient);
            var d = oauthclients.ToList();
            return new List<OAuthClient>(d);
        }
    }
}
