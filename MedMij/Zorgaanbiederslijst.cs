// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class Zorgaanbiederslijst: IReadOnlyDictionary<string, Zorgaanbieder>
    {
        public static readonly XNamespace NS = "xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/";
        public static readonly XName ZorgaanbiederslijstRoot = NS + "Zorgaanbiederslijst";
        private static readonly XmlSchemaSet Schemas = XMLUtils.SchemaSetFromResource("Zorgaanbiederslijst.xsd", NS);

        private Dictionary<string, Zorgaanbieder> _dict;

        public IEnumerable<string> Keys => ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).Keys;

        public IEnumerable<Zorgaanbieder> Values => ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).Values;

        public int Count => ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).Count;

        public Zorgaanbieder this[string key] => ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict)[key];

        private Zorgaanbiederslijst(XDocument doc)
        {
            XMLUtils.Validate(doc, Schemas, ZorgaanbiederslijstRoot);

        }

        public static Zorgaanbiederslijst FromXMLData(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);
            return new Zorgaanbiederslijst(doc);
        }

        public static async Task<Zorgaanbiederslijst> FromURL(string url, System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            using (var c = httpClientFactory.CreateClient())
            {
                var data = await c.GetStringAsync(url).ConfigureAwait(false);
                return FromXMLData(data);
            }
        }

        public bool ContainsKey(string key)
        {
            return ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).ContainsKey(key);
        }

        public bool TryGetValue(string key, out Zorgaanbieder value)
        {
            return ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<string, Zorgaanbieder>> GetEnumerator()
        {
            return ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyDictionary<string, Zorgaanbieder>)_dict).GetEnumerator();
        }
    }
}
