// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;
    public class ZorgaanbiederslijstTest
    {
        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML)]
        public void ZorgaanbiedersCollectionParseOK(string xmlData)
        {
            Zorgaanbiederslijst.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML)]
        public void ZorgaanbiedersCollectionIsIterable(string xmlData)
        {
            var col = Zorgaanbiederslijst.FromXMLData(xmlData);
            foreach (var c in col.Data)
            {
                System.Console.WriteLine(c.Naam);
                foreach (var pair in c.Gegevensdiensten)
                {
                    System.Console.WriteLine($"{pair.Key} == {pair.Value.Id}");
                    System.Console.WriteLine(pair.Value.AuthorizationEndpointUri);
                    System.Console.WriteLine(pair.Value.TokenEndpointUri);
                }
                System.Console.WriteLine();
            }
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.InvalidXML)]
        public void ZorgaanbiedersCollectionInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => Zorgaanbiederslijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionXSDFail1)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionXSDFail2)]
        public void ZorgaanbiedersCollectionXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => Zorgaanbiederslijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("umcharderwijk@medmij")]
        [InlineData("radiologencentraalflevoland@medmij")]
        public void ZorgaanbiedersCollectionContains(string name)
        {
            var zorgaanbieders = Zorgaanbiederslijst.FromXMLData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML);
            Assert.NotNull(zorgaanbieders.GetByName(name));
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "umcharderwijk")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "UMCHarderwijk@medmij")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML, "")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML, "umcharderwijk@medmij")]
        public void ZorgaanbiedersCollectionNotContains(string xml, string name)
        {
            var zorgaanbieders = Zorgaanbiederslijst.FromXMLData(xml);
            Assert.Throws<KeyNotFoundException>(() => zorgaanbieders.GetByName(name));
        }
    }
}
