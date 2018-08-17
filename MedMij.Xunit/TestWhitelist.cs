//  Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

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
        public void WhiteListParseOK(string xmlData)
        {
            var whitelist = WhiteList.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(TestData.WhitelistInvalidXML)]
        public void WhitelistInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => WhiteList.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(TestData.WhitelistXSDFail1)]
        [InlineData(TestData.WhitelistXSDFail2)]
        public void WhitelistXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => WhiteList.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("rcf-rso.nl")]
        public void WhiteListContains(string hostname)
        {
            var whitelist = WhiteList.FromXMLData(TestData.WhiltelistExampleXML);
            Assert.True(whitelist.Contains(hostname));
        }

        [Theory]
        [InlineData("rcf-rso.nl.")]
        [InlineData("RCF-RSO.NL")]
        [InlineData("")]
        public void WhiteListNotContains(string hostname)
        {
            var whitelist = WhiteList.FromXMLData(TestData.WhiltelistExampleXML);
            Assert.False(whitelist.Contains(hostname));
        }

        [Theory]
        [InlineData(TestData.WhitelistURL)]
        public async Task<WhiteList> WhiteListDownload(string url)
        {
            return await WhiteList.FromURL(url).ConfigureAwait(false);
        }
    }
}
