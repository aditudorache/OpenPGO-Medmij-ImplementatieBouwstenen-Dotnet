// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;

    public class WhitelistTest
    {
        [Theory]
        [InlineData(WhitelistTestMock.WhiltelistExampleXML)]
        [InlineData(WhitelistTestMock.WhiltelistSingleXML)]
        public void WhitelistParseOK(string xmlData)
        {
            var whitelist = Whitelist.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(WhitelistTestMock.InvalidXML)]
        public void WhitelistInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => Whitelist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(WhitelistTestMock.WhitelistXSDFail1)]
        [InlineData(WhitelistTestMock.WhitelistXSDFail2)]
        public void WhitelistXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => Whitelist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("rcf-rso.nl")]
        public void WhitelistContains(string hostname)
        {
            var whitelist = Whitelist.FromXMLData(WhitelistTestMock.WhiltelistExampleXML);
            Assert.True(whitelist.IsMedMijNode(hostname));
        }

        [Theory]
        [InlineData("rcf-rso.nl.")]
        [InlineData("RCF-RSO.NL")]
        [InlineData("")]
        [InlineData(null)]
        public void WhitelistNotContains(string hostname)
        {
            var whitelist = Whitelist.FromXMLData(WhitelistTestMock.WhiltelistExampleXML);
            Assert.False(whitelist.IsMedMijNode(hostname));
        }
    }
}
