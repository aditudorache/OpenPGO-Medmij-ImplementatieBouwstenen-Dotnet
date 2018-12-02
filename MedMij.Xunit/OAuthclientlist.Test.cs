// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;
    public class OAuthclientlistTest
    {
        [Theory]
        [InlineData(TestData.OAuthClientCollectionExampleXML)]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionParseOK(string xmlData)
        {
            OAuthclientlist.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(TestData.OAuthClientCollectionExampleXML)]
        [InlineData(TestData.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionIsIterable(string xmlData)
        {
            var col = OAuthclientlist.FromXMLData(xmlData);
            foreach (var c in col.Data)
            {
                System.Console.WriteLine(c.Organisatienaam);
            }
        }

        [Theory]
        [InlineData(TestData.InvalidXML)]
        public void OAuthClientCollectionInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => OAuthclientlist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(TestData.OAuthClientCollectionXSDFail1)]
        [InlineData(TestData.OAuthClientCollectionXSDFail2)]
        public void OAuthClientCollectionXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => OAuthclientlist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("Unstealth Health Midden-Nederland")]
        [InlineData("De Enige Echte PGO")]
        public void OAuthClientCollectionContains(string name)
        {
            var OAuthClient = OAuthclientlist.FromXMLData(TestData.OAuthClientCollectionExampleXML);
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
            var OAuthClient = OAuthclientlist.FromXMLData(xml);
            Assert.Throws<KeyNotFoundException>(() => OAuthClient.GetByOrganisatienaam(name));
        }

    }
}
