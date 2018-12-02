// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;
    public class TestOAuthClientCollection
    {
        [Theory]
        [InlineData(TestData.OAuthClientCollectionExampleXML)]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionParseOK(string xmlData)
        {
            OAuthClientCollection.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(TestData.OAuthClientCollectionExampleXML)]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionIsIterable(string xmlData)
        {
            var col = OAuthClientCollection.FromXMLData(xmlData);
            foreach (var c in col)
            {
                System.Console.WriteLine(c.Organisatienaam);
            }
        }

        [Theory]
        [InlineData(TestData.InvalidXML)]
        public void OAuthClientCollectionInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => OAuthClientCollection.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(TestData.OAuthClientCollectionXSDFail1)]
        [InlineData(TestData.OAuthClientCollectionXSDFail2)]
        public void OAuthClientCollectionXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => OAuthClientCollection.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("Unstealth Health Midden-Nederland")]
        [InlineData("De Enige Echte PGO")]
        public void OAuthClientCollectionContains(string name)
        {
            var OAuthClient = OAuthClientCollection.FromXMLData(TestData.OAuthClientCollectionExampleXML);
            Assert.NotNull(OAuthClient.GetByOrganisatienaam(name));
        }

        [Theory]
        [InlineData(TestData.OAuthClientCollectionExampleXML, "De enige Echte PGO")]
        [InlineData(TestData.OAuthClientCollectionExampleXML, "De Enige Echte PGO ")]
        [InlineData(TestData.OAuthClientCollectionExampleXML, "")]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML, "")]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML, "De Enige Echte PGO")]
        public void OAuthClientCollectionNotContains(string xml, string name)
        {
            var OAuthClient = OAuthClientCollection.FromXMLData(xml);
            Assert.Throws<KeyNotFoundException>(() => OAuthClient.GetByOrganisatienaam(name));
        }

    }
}
