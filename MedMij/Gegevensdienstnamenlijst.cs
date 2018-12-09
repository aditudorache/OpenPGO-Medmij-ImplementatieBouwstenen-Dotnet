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
    /// Een gegevensdienstnamenlijst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Gegevensdienstnamenlijst : MedMijListBase<Gegevensdienstnaam>
    {
        private static readonly XName GegevensdienstName = NS + "Gegevensdienst";
        private static readonly XName GegevensdienstIdName = NS + "GegevensdienstId";
        private static readonly XName WeergavenaamName = NS + "Weergavenaam";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource(MedMijDefinitions.XsdName(MedMijDefinitions.Gegevensdienstnamenlijst), NS);

        private Gegevensdienstnamenlijst(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, GegevensdienstnamenlijstRoot);
            Data = ParseXml(doc);
        }

        private static XNamespace NS => MedMijDefinitions.GegevensdienstnamenlijstNamespace;
        private static XName GegevensdienstnamenlijstRoot => NS + MedMijDefinitions.Gegevensdienstnamenlijst;

        /// <summary>
        /// Initialiseert een <see cref="Gegevensdienstnamenlijst"/> vanuit een string. Parset de string and valideert deze.
        /// </summary>
        /// <param name="xmlData">Een string met de zorgaanbiederslijst als XML.</param>
        /// <returns>De nieuwe <see cref="Gegevensdienstnamenlijst"/>.</returns>
        public static Gegevensdienstnamenlijst FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Gegevensdienstnamenlijst(doc);
        }

        /// <summary>
        /// Returns a dictionary with mapping from id to gegevensdienst name
        /// </summary>
        /// <returns>A dictionary with the names</returns>
        public Dictionary<string, string> GetMapIdToName()
        {
            return Data.ToDictionary(p => p.GegevensdienstId, p => p.Weergavenaam);
        }

        /// <summary>
        /// Parses the xml document to the list
        /// </summary>
        /// <param name="doc">The xml document</param>
        /// <returns>A list with data</returns>
        protected override List<Gegevensdienstnaam> ParseXml(XDocument doc)
        {
            Gegevensdienstnaam MapElement(XElement x)
                => new Gegevensdienstnaam
                {
                    GegevensdienstId = x.Element(GegevensdienstIdName).Value,
                    Weergavenaam = x.Element(WeergavenaamName).Value
                };

            var gegevensdinstnamen = doc.Descendants(GegevensdienstName).Select(MapElement);
            return gegevensdinstnamen.ToList();
        }
    }
}
