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
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML)]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionParseOK(string xmlData)
        {
            OAuthclientlist.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML)]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionEmptyExampleXML)]
        public void OAuthClientCollectionIsIterable(string xmlData)
        {
            var col = OAuthclientlist.FromXMLData(xmlData);
            foreach (var c in col.Data)
            {
                System.Console.WriteLine(c.Organisatienaam);
            }
        }

        [Theory]
        [InlineData(OAuthclientlistTestMock.InvalidXML)]
        public void OAuthClientCollectionInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => OAuthclientlist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionXSDFail1)]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionXSDFail2)]
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
            var OAuthClient = OAuthclientlist.FromXMLData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML);
            Assert.NotNull(OAuthClient.GetByOrganisatienaam(name));
        }

        [Theory]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML, "De enige Echte PGO")]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML, "De Enige Echte PGO ")]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionExampleXML, "")]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionEmptyExampleXML, "")]
        [InlineData(OAuthclientlistTestMock.OAuthClientCollectionEmptyExampleXML, "De Enige Echte PGO")]
        public void OAuthClientCollectionNotContains(string xml, string name)
        {
            var OAuthClient = OAuthclientlist.FromXMLData(xml);
            Assert.Throws<KeyNotFoundException>(() => OAuthClient.GetByOrganisatienaam(name));
        }

    }
}
