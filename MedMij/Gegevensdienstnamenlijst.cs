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
    public class Gegevensdienstnamenlijst
    {
        private static XNamespace NS => Definitions.GegevensdienstnamenlijstNamespace;
        private static XName GegevensdienstnamenlijstRoot => NS + Definitions.Gegevensdienstnamenlijst;
        private static readonly XName GegevensdienstName = NS + "Gegevensdienst";
        private static readonly XName GegevensdienstIdName = NS + "GegevensdienstId";
        private static readonly XName WeergavenaamName = NS + "Weergavenaam";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource(Definitions.XsdName(Definitions.Gegevensdienstnamenlijst), NS);

        private readonly List<Gegevensdinstnaam> data;

        private Gegevensdienstnamenlijst(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, GegevensdienstnamenlijstRoot);
            this.data = Parse(doc);
        }

        public List<Gegevensdinstnaam> Data => data;

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
        /// Returns a dictionary with the Gegevensdinstnaam.Weergave
        /// </summary>
        public Dictionary<string, string> GetMapIdToName()
        {
            return this.data.ToDictionary(p => p.GegevensdienstId, p => p.Weergavenaam);
        }

        private static List<Gegevensdinstnaam> Parse(XDocument doc)
        {
            Gegevensdinstnaam MapElement(XElement x)
                => new Gegevensdinstnaam
                {
                    GegevensdienstId = x.Element(GegevensdienstIdName).Value,
                    Weergavenaam = x.Element(WeergavenaamName).Value
                };

            var gegevensdinstnamen = doc.Descendants(GegevensdienstName).Select(MapElement);
            return gegevensdinstnamen.ToList();
        }
    }
}
