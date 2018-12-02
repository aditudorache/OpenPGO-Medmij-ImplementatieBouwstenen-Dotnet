// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;

    public class TestWhitelist
    {
        [Theory]
        [InlineData(TestData.WhiltelistExampleXML)]
        [InlineData(TestData.WhiltelistSingleXML)]
        public void WhitelistParseOK(string xmlData)
        {
            var whitelist = Whitelist.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(TestData.InvalidXML)]
        public void WhitelistInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => Whitelist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(TestData.WhitelistXSDFail1)]
        [InlineData(TestData.WhitelistXSDFail2)]
        public void WhitelistXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => Whitelist.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("rcf-rso.nl")]
        public void WhitelistContains(string hostname)
        {
            var whitelist = Whitelist.FromXMLData(TestData.WhiltelistExampleXML);
            Assert.True(whitelist.Contains(hostname));
        }

        [Theory]
        [InlineData("rcf-rso.nl.")]
        [InlineData("RCF-RSO.NL")]
        [InlineData("")]
        [InlineData(null)]
        public void WhitelistNotContains(string hostname)
        {
            var whitelist = Whitelist.FromXMLData(TestData.WhiltelistExampleXML);
            Assert.False(whitelist.Contains(hostname));
        }
    }
}
