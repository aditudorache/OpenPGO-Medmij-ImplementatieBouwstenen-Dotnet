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
    /// Een zorgaanbiederslijst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Zorgaanbiederslijst : MedMijListBase<Zorgaanbieder>
    {
        private static readonly XName ZorgaanbiederName = NS + "Zorgaanbieder";
        private static readonly XName ZorgaanbiedernaamName = NS + "Zorgaanbiedernaam";
        private static readonly XName GegevensdienstName = NS + "Gegevensdienst";
        private static readonly XName GegevensdienstIdName = NS + "GegevensdienstId";
        private static readonly XName AuthorizationEndpointuriName = NS + "AuthorizationEndpointuri";
        private static readonly XName TokenEndpointuriName = NS + "TokenEndpointuri";

        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource(MedMijDefinitions.XsdName(MedMijDefinitions.Zorgaanbiederslijst), NS);

        private Zorgaanbiederslijst(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, ZorgaanbiederslijstRoot);
            Data = ParseXml(doc);
        }

        private static XNamespace NS => MedMijDefinitions.ZorgaanbiederslijstNamespace;
        private static XName ZorgaanbiederslijstRoot => NS + MedMijDefinitions.Zorgaanbiederslijst;

        /// <summary>
        /// Initialiseert een <see cref="Zorgaanbiederslijst"/> vanuit een string. Parset de string and valideert deze.
        /// </summary>
        /// <param name="xmlData">Een string met de zorgaanbiederslijst als XML.</param>
        /// <returns>De nieuwe <see cref="Zorgaanbiederslijst"/>.</returns>
        public static Zorgaanbiederslijst FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Zorgaanbiederslijst(doc);
        }

        /// <summary>
        /// Geeft de <see cref="Zorgaanbieder"/> met de opgegeven naam.
        /// </summary>
        /// <param name="name">De naam van de <see cref="Zorgaanbieder"/></param>
        /// <returns>De gezochte <see cref="Zorgaanbieder"/>.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Wordt gegenereerd als de naam niet wordt gevonden.</exception>
        public Zorgaanbieder GetByName(string name)
        {
            var zorgaanbieder = Data.FirstOrDefault(p => p.Naam == name);
            if (zorgaanbieder == null)
                throw new KeyNotFoundException();
            return zorgaanbieder;
        }

        /// <summary>
        /// Parses the xml document to the list
        /// </summary>
        /// <param name="doc">The xml document</param>
        /// <returns>A list with data</returns>
        protected override List<Zorgaanbieder> ParseXml(XDocument doc)
        {
            Gegevensdienst ParseGegevensdienst(XElement x, string zorgaanbiedernaam)
            {
                var id = x.Element(GegevensdienstIdName).Value;
                var authorizationEndpointUri = x.Descendants(AuthorizationEndpointuriName).Single().Value;
                var tokenEndpointUri = x.Descendants(TokenEndpointuriName).Single().Value;
                return new Gegevensdienst(
                    id: id,
                    zorgaanbiedernaam: zorgaanbiedernaam,
                    authorizationEndpointUri: new Uri(authorizationEndpointUri),
                    tokenEndpointUri: new Uri(tokenEndpointUri));
            }

            Zorgaanbieder ParseZorgaanbieder(XElement x)
            {
                var naam = x.Element(ZorgaanbiedernaamName).Value;
                var gegevensdiensten = x.Descendants(GegevensdienstName)
                                        .Select(e => ParseGegevensdienst(e, naam))
                                        .ToDictionary(g => g.Id, g => g);
                return new Zorgaanbieder(naam: naam, gegevensdiensten: gegevensdiensten);
            }

            var zorgaanbieders = doc.Descendants(ZorgaanbiederName).Select(ParseZorgaanbieder);
            return zorgaanbieders.ToList();
        }
    }
}
